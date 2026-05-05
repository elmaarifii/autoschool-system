const demoSlots = [
    { id: 1, instructorName: "Arben", date: "2026-05-04T00:00:00", time: "14:00", isBooked: false },
    { id: 2, instructorName: "Arben", date: "2026-04-01T00:00:00", time: "12:00", isBooked: false },
    { id: 3, instructorName: "Driton", date: "2026-04-02T00:00:00", time: "09:00", isBooked: false },
    { id: 4, instructorName: "Driton", date: "2026-04-02T00:00:00", time: "11:00", isBooked: true },
    { id: 5, instructorName: "Luan", date: "2026-04-03T00:00:00", time: "14:00", isBooked: false },
    { id: 6, instructorName: "Arian", date: "2026-04-10T00:00:00", time: "15:00", isBooked: false },
    { id: 7, instructorName: "Arber", date: "2026-04-20T00:00:00", time: "12:30", isBooked: false }
];

let currentSlots = [];
let usingDemoData = false;

function getApiBase() {
    return document.getElementById("apiBase").value.trim().replace(/\/$/, "");
}

function buildSlotsUrl() {
    const instructor = document.getElementById("instructor").value.trim();
    const status = document.getElementById("status").value;
    const params = new URLSearchParams();

    if (instructor) {
        params.append("instructorName", instructor);
    }

    if (status !== "") {
        params.append("isBooked", status);
    }

    const queryString = params.toString();
    return `${getApiBase()}/api/Slots${queryString ? `?${queryString}` : ""}`;
}

function formatDate(value) {
    if (!value) {
        return "-";
    }

    return value.split("T")[0];
}

function setMessage(text, type = "info") {
    const message = document.getElementById("message");
    message.textContent = text;
    message.className = `message ${type}`;
}

function updateStats(slots) {
    const instructors = new Set(slots.map(slot => slot.instructorName));
    const booked = slots.filter(slot => slot.isBooked).length;

    document.getElementById("totalSlots").textContent = slots.length;
    document.getElementById("freeSlots").textContent = slots.length - booked;
    document.getElementById("bookedSlots").textContent = booked;
    document.getElementById("instructorCount").textContent = instructors.size;
}

function renderSlots(slots) {
    const table = document.getElementById("tableBody");

    if (slots.length === 0) {
        table.innerHTML = `
            <tr>
                <td colspan="6" class="empty-state">Nuk u gjet asnje slot me keto filtra.</td>
            </tr>
        `;
        updateStats(slots);
        return;
    }

    table.innerHTML = slots.map(slot => {
        const statusClass = slot.isBooked ? "status-booked" : "status-free";
        const statusText = slot.isBooked ? "I rezervuar" : "I lire";
        const actionText = slot.isBooked ? "Liro" : "Rezervo";
        const actionClass = slot.isBooked ? "quiet-btn" : "action-btn";

        return `
            <tr>
                <td>#${slot.id}</td>
                <td>
                    <div class="instructor-cell">
                        <span>${slot.instructorName.charAt(0).toUpperCase()}</span>
                        ${slot.instructorName}
                    </div>
                </td>
                <td>${formatDate(slot.date)}</td>
                <td>${slot.time}</td>
                <td><span class="status-pill ${statusClass}">${statusText}</span></td>
                <td>
                    <button class="${actionClass}" type="button" data-action="${slot.isBooked ? "release" : "book"}" data-id="${slot.id}">
                        ${actionText}
                    </button>
                </td>
            </tr>
        `;
    }).join("");

    updateStats(slots);
}

function getFilteredDemoSlots() {
    const instructor = document.getElementById("instructor").value.trim().toLowerCase();
    const status = document.getElementById("status").value;

    return demoSlots.filter(slot => {
        const matchesInstructor = !instructor || slot.instructorName.toLowerCase().includes(instructor);
        const matchesStatus = status === "" || String(slot.isBooked) === status;
        return matchesInstructor && matchesStatus;
    });
}

async function loadSlots() {
    try {
        setMessage("Duke ngarkuar te dhenat nga API...", "info");
        usingDemoData = false;

        const response = await fetch(buildSlotsUrl());
        if (!response.ok) {
            throw new Error(`Server returned ${response.status}`);
        }

        currentSlots = await response.json();
        renderSlots(currentSlots);
        setMessage(`${currentSlots.length} slot-e u ngarkuan nga API.`, "success");
    } catch (error) {
        usingDemoData = true;
        currentSlots = getFilteredDemoSlots();
        renderSlots(currentSlots);
        setMessage("API nuk u lidh. Po shfaqen te dhena demo per plan B.", "warning");
        console.error(error);
    }
}

async function toggleSlot(id, action) {
    if (usingDemoData) {
        const slot = demoSlots.find(item => item.id === id);
        if (slot) {
            slot.isBooked = action === "book";
        }

        currentSlots = getFilteredDemoSlots();
        renderSlots(currentSlots);
        setMessage("Statusi u ndryshua ne te dhenat demo.", "success");
        return;
    }

    try {
        setMessage("Duke perditesuar statusin...", "info");
        const response = await fetch(`${getApiBase()}/api/Slots/${id}/${action}`, { method: "POST" });

        if (!response.ok) {
            const text = await response.text();
            throw new Error(text || `Server returned ${response.status}`);
        }

        await loadSlots();
        setMessage(action === "book" ? "Rezervimi u krye me sukses." : "Rezervimi u anulua me sukses.", "success");
    } catch (error) {
        setMessage("Nuk u perditesua statusi. Kontrollo API-ne ose perdor plan B.", "warning");
        console.error(error);
    }
}

document.getElementById("loadSlotsBtn").addEventListener("click", loadSlots);
document.getElementById("applyFiltersBtn").addEventListener("click", loadSlots);
document.getElementById("resetFiltersBtn").addEventListener("click", () => {
    document.getElementById("instructor").value = "";
    document.getElementById("status").value = "";
    loadSlots();
});

document.getElementById("tableBody").addEventListener("click", event => {
    const button = event.target.closest("button[data-action]");
    if (!button) {
        return;
    }

    toggleSlot(Number(button.dataset.id), button.dataset.action);
});

window.addEventListener("DOMContentLoaded", loadSlots);
