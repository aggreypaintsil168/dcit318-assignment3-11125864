# Third C# Assignment 3


# 📘 DCIT 318 – Programming II Assignment 3 Guide

## Finance Management System

**Goal**: Track transactions and enforce account rules using **interfaces, records, and sealed classes**.

* **Records**: `Transaction` record holds immutable transaction data (Id, Date, Amount, Category).
* **Interfaces**: `ITransactionProcessor` defines how transactions are processed.

  * Implemented by `BankTransferProcessor`, `MobileMoneyProcessor`, `CryptoWalletProcessor`. Each prints a distinct processing message.
* **Inheritance & Sealed Class**:

  * `Account` base class manages balances.
  * `SavingsAccount` (sealed) ensures no further inheritance. Prevents overdrafts with “Insufficient funds” check.
* **Application Flow**:

  * Create a savings account with a starting balance.
  * Process three sample transactions with different processors.
  * Apply transactions to the account and display balances.

📌 **Concepts shown**: Records (immutability), Interfaces (polymorphism), Sealed classes (inheritance control).


## Healthcare System

**Goal**: Manage patient records and prescriptions using **generics, collections, and dictionaries**.

* **Generic Repository**: `Repository<T>` supports Add, GetAll, GetById, Remove for reusable entity storage.
* **Entities**:

  * `Patient` with Id, Name, Age, Gender.
  * `Prescription` with Id, PatientId, MedicationName, DateIssued.
* **Dictionary Mapping**:

  * `Dictionary<int, List<Prescription>>` maps each patient to their prescriptions.
* **HealthSystemApp**:

  * `SeedData()` → adds patients & prescriptions.
  * `BuildPrescriptionMap()` → groups prescriptions by patient.
  * `PrintAllPatients()` → lists patients.
  * `PrintPrescriptionsForPatient(id)` → lists prescriptions for a chosen patient.

📌 **Concepts shown**: Generics (type-safe repository), Collections (`List`, `Dictionary`), Data grouping.


## Warehouse Inventory System

**Goal**: Manage warehouse inventory with **generics, marker interfaces, and custom exceptions**.

* **Marker Interface**: `IInventoryItem` with Id, Name, Quantity.
* **Product Classes**:

  * `ElectronicItem` → adds Brand, WarrantyMonths.
  * `GroceryItem` → adds ExpiryDate.
* **Generic Repository**: `InventoryRepository<T>` with methods AddItem, GetItemById, RemoveItem, GetAllItems, UpdateQuantity.

  * Uses exceptions: `DuplicateItemException`, `ItemNotFoundException`, `InvalidQuantityException`.
* **WarehouseManager**:

  * Manages electronics and groceries.
  * Seeds data, prints items, updates/removes items with try-catch for safe error handling.
* **Main Flow**:

  * Seed inventory.
  * Print groceries & electronics.
  * Demonstrate exception handling by trying duplicate add, removing non-existent item, invalid quantity update.

📌 **Concepts shown**: Generics (repo), Marker interface, Exception handling.


## School Grading System

**Goal**: Read student data from a text file, validate, assign grades, and generate a clean report.

* **Student Class**: Holds Id, FullName, Score. Method `GetGrade()` assigns letter grades (A–F).
* **Custom Exceptions**:

  * `InvalidScoreFormatException` → invalid score parsing.
  * `MissingFieldException` → missing ID/Name/Score.
* **StudentResultProcessor**:

  * `ReadStudentsFromFile(path)` → validates and loads student data.
  * `WriteReportToFile(path)` → writes clean summary with grades.
* **Main Flow**:

  * Wrap entire process in try-catch.
  * Handle errors: missing file, invalid score, missing fields, and unexpected errors.
  * Write output report like:

    ```
    Alice Smith (ID: 101): Score = 84, Grade = A
    ```

📌 **Concepts shown**: File I/O, Custom exceptions, Exception-safe processing.


## Inventory Logging System

**Goal**: Capture inventory records using **records, generics, and file persistence**.

* **Immutable Record**: `InventoryItem` (Id, Name, Quantity, DateAdded).
* **Marker Interface**: `IInventoryEntity` with Id property. Implemented by `InventoryItem`.
* **Generic Logger**: `InventoryLogger<T>` (where T : IInventoryEntity).

  * Add items, GetAll, SaveToFile (JSON or text), LoadFromFile.
  * File operations wrapped with `using` and try-catch.
* **InventoryApp**:

  * `SeedSampleData()` → adds sample items.
  * `SaveData()` → persists items to file.
  * `LoadData()` → reads back data.
  * `PrintAllItems()` → displays recovered inventory.
* **Main Flow**:

  * Seed data.
  * Save to disk.
  * Simulate new session (clear memory).
  * Reload data and confirm recovery.

📌 **Concepts shown**: Records (immutability), Generics (logger), File operations (serialization, exception handling).


