## Class Diagram (UML)

```mermaid
classDiagram

class User {
  -int Id
  -string Name
  -string Email
  -string Password
  -string Role
}

class AvailableSlot {
  -int Id
  -DateTime Date
  -bool IsBooked
}

class Booking {
  -int Id
  -int UserId
  -int SlotId
}

class Material {
  -int Id
  -string Title
  -string Content
}

class Quiz {
  -int Id
  -string Title
}

class IRepository~T~ {
  +GetAll()
  +GetById(id)
  +Add(entity)
  +Save()
}

class FileRepository~T~ {
}

IRepository <|.. FileRepository

User --> Booking
Booking --> AvailableSlot
User --> Material
User --> Quiz
