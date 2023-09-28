# Style Guide

This document describes the style guide for the C# code in this project.

## Table of Contents

- [Naming Conventions](#naming-conventions)
  - [File Names](#file-names)
  - [Type Names](#type-names)
  - [Member Names](#member-names)
  - [Constant Names](#constant-names)
  - [Namespace Names](#namespace-names)
- [Layout Conventions](#layout-conventions)
  - [Indentation](#indentation)
  - [Line Length](#line-length)
  - [Braces](#braces)
  - [Blank Lines](#blank-lines)
  - [Comments](#comments)
  - [Documentation](#documentation)
  - [Layout of Elements](#layout-of-elements)

## Naming Conventions

The following naming conventions apply to all C# code in this project.

### File Names

File names should be descriptive and use pascal case. The file name should match the name of the single type declared in the file.

### Type Names

Type names should be descriptive and use pascal case. Type names should be singular unless they are explicitly declared as a collection.

### Member Names

Member names should be descriptive and use pascal case. Member names should be singular unless they are explicitly declared as a collection.

### Constant Names

Constant names should be descriptive and use pascal case. Constant names should be singular unless they are explicitly declared as a collection.

### Namespace Names

Namespace names should be descriptive and use pascal case.

## Layout Conventions

The following layout conventions apply to all C# code in this project.

### Indentation

Indentation should be done using spaces. The default indentation size is 4 spaces.

### Line Length

Lines should be no longer than 120 characters.

### Braces

Braces should be placed on the same line as the statement that requires them.

### Blank Lines

Blank lines should be used to separate logical sections of code.

### Comments

Comment

### Documentation

Documentation

### Layout of Elements

Elements at the file root level or within a namespace must be positioned in the following order:

- Extern Alias Directives
- Using Directives
- Namespaces
- Delegates
- Enums
- Interfaces
- Structs
- Classes

Within a class, struct, or interface, elements must be positioned in the following order:

- Fields
- Constructors
- Finalizers (Destructors)
- Delegates
- Events
- Enums
- Interfaces
- Properties
- Indexers
- Methods
- Structs
- Classes

Complying with a standard ordering scheme based on element type can increase the readability and maintainability of the file and encourage code reuse.

When implementing an interface, it is sometimes desirable to group all members of the interface next to one another. This will sometimes require violating this rule, if the interface contains elements of different types. This problem can be solved through the use of partial classes.

- Add the partial attribute to the class, if the class is not already partial.
- Add a second partial class with the same name within a second file.
- Move the interface inheritance and all members of the interface implementation to the second part of the class.
