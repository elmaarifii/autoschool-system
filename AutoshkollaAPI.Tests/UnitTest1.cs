using AutoshkollaAPI.Data;
using AutoshkollaAPI.Models;
using AutoshkollaAPI.Services;

namespace AutoshkollaAPI.Tests;

public class SlotServiceTests
{
    [Fact]
    public void Add_ValidSlot_AddsSuccessfully()
    {
        var filePath = CreateTempCsv();

        try
        {
            var service = new SlotService(new FileRepository<AvailableSlot>(filePath));
            var slot = new AvailableSlot
            {
                Id = 1,
                InstructorName = "Arben",
                Date = new DateTime(2026, 4, 6),
                Time = "09:00",
                IsBooked = false
            };

            service.Add(slot);
            var added = service.GetById(1);

            Assert.NotNull(added);
            Assert.Equal("Arben", added!.InstructorName);
        }
        finally
        {
            CleanupTempFile(filePath);
        }
    }

    [Fact]
    public void Add_EmptyInstructorName_ThrowsException()
    {
        var filePath = CreateTempCsv();

        try
        {
            var service = new SlotService(new FileRepository<AvailableSlot>(filePath));
            var invalid = new AvailableSlot
            {
                Id = 2,
                InstructorName = " ",
                Date = new DateTime(2026, 4, 6),
                Time = "10:00",
                IsBooked = false
            };

            var ex = Assert.Throws<Exception>(() => service.Add(invalid));
            Assert.Equal("Instructor name cannot be empty", ex.Message);
        }
        finally
        {
            CleanupTempFile(filePath);
        }
    }

    [Fact]
    public void Search_ExistingInstructor_ReturnsMatchingSlots()
    {
        var filePath = CreateTempCsv(
            "1,Arben,2026-04-06,09:00,false",
            "2,Besa,2026-04-06,10:00,true");

        try
        {
            var service = new SlotService(new FileRepository<AvailableSlot>(filePath));
            var result = service.GetAll("Arben");

            Assert.Single(result);
            Assert.Equal("Arben", result[0].InstructorName);
        }
        finally
        {
            CleanupTempFile(filePath);
        }
    }

    [Fact]
    public void Search_NonExistingInstructor_ReturnsEmptyList()
    {
        var filePath = CreateTempCsv(
            "1,Arben,2026-04-06,09:00,false",
            "2,Besa,2026-04-06,10:00,true");

        try
        {
            var service = new SlotService(new FileRepository<AvailableSlot>(filePath));
            var result = service.GetAll("Nuk-Ekziston");

            Assert.Empty(result);
        }
        finally
        {
            CleanupTempFile(filePath);
        }
    }

    private static string CreateTempCsv(params string[] dataRows)
    {
        var filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.csv");
        var lines = new List<string> { "Id,InstructorName,Date,Time,IsBooked" };
        lines.AddRange(dataRows);
        File.WriteAllLines(filePath, lines);
        return filePath;
    }

    private static void CleanupTempFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
