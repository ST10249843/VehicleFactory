# Vehicle Factory Ordering System (WPF - C#)

## Overview

This application is a WPF-based desktop system developed in C#. It allows users to order a vehicle by selecting both the vehicle type and engine type. The project demonstrates the use of the **Factory Method** and **Abstract Factory** design patterns to ensure proper object creation, separation of concerns, and scalability.

## Features

- Selection of vehicle types: Car, Motorcycle, and Truck.
- Selection of engine types: Electric, Gasoline, and Hybrid.
- Engine options are context-aware, meaning they are restricted based on the selected vehicle type.
- Confirmation message displays the selected vehicle and engine.
- A clean and modern red-themed WPF user interface.

## Design Patterns Implemented

### Factory Method

The Factory Method pattern is used to create vehicle instances without exposing the instantiation logic to the client. This allows the program to determine the correct subclass at runtime based on user input.

- **IVehicle**: The common interface implemented by all vehicle types (`Car`, `Motorcycle`, `Truck`).
- **VehicleFactory**: An abstract class that defines the method for creating vehicles.
- **CarFactory**, **MotorcycleFactory**, **TruckFactory**: Concrete factories that instantiate the respective vehicle types.

### Abstract Factory

The Abstract Factory pattern is used to ensure that each vehicle is paired with a compatible set of engine options.

- **IEngine**: Interface implemented by all engine types.
- **ElectricEngine**, **GasolineEngine**, **HybridEngine**: Concrete implementations of different engine types.
- **IEngineFactory**: Interface for engine creation factories.
- **CarEngineFactory**, **MotorcycleEngineFactory**, **TruckEngineFactory**: Return only valid engine types for the selected vehicle.

## User Interface

The user interface is developed using WPF with XAML. It includes:

- A ComboBox for vehicle selection.
- A dynamically populated ComboBox for engine selection based on the selected vehicle.
- An "Order Vehicle" button to confirm the order.
- A TextBlock that displays the result (confirmation message).

Styling and layout:
- Red-themed design for a bold and clean visual aesthetic.
- Responsive layout with proper padding, margin, and alignment.
- Compatibility ensured with .NET Framework and C# 7.3 and above.

## Design Rationale

- **Separation of Concerns**: Vehicle and engine creation responsibilities are decoupled.
- **Extensibility**: New vehicle or engine types can be added without modifying existing logic.
- **Maintainability**: The design promotes clear responsibility assignments and modular code organization.
- **User Feedback**: A confirmation message provides clear feedback after each order is placed.

## Challenges Encountered

| Challenge | Resolution |
|-----------|------------|
| Preventing incompatible engine and vehicle pairings | Implemented Abstract Factory to restrict engine options per vehicle type |
| WPF UI spacing not supported in older frameworks | Replaced unsupported `Spacing` property with appropriate margin and padding |
| Maintaining code readability with multiple design patterns | Used interface-based abstraction and separated logic into distinct factory classes |
| Ensuring forward compatibility | Used only features available in C# 7.3 to avoid build issues in environments with restricted versions |

## Benefits of Using the Factory Patterns

- **Encapsulation of Creation Logic**: Clients do not need to know the concrete classes being instantiated.
- **Improved Testability**: Factories can be mocked or extended easily for testing.
- **Open/Closed Principle**: System can be extended with new types without modifying existing code.
- **Code Reusability**: Common logic can be reused across different components.

## Future Enhancements

- Store user orders in a local database or file.
- Implement additional vehicle properties such as color or model year.
- Add data validation and error handling for better robustness.
- Improve UI with visual previews of selected vehicles and engines.

## Summary

This system provides a clean implementation of both the Factory Method and Abstract Factory patterns within a WPF application. It offers a user-friendly way to simulate vehicle ordering while adhering to best practices in object-oriented design.
