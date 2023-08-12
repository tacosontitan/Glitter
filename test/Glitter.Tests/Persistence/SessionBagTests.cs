/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

// using System;
// using System.Collections.Generic;
// using Xunit;
//
// namespace Glitter.Persistence.Tests;
//
// public class SessionBagTests
// {
//     [Fact]
//     public void CanAddAndGetNamedValue()
//     {
//         // Arrange
//         var bag = new SessionBag();
//         string key = "myKey";
//         string value = "myValue";
//
//         // Act
//         bag[key] = value;
//         object? result = bag[key];
//
//         // Assert
//         Assert.Equal(value, result);
//     }
//
//     [Fact]
//     public void CanAddAndGetTypedValue()
//     {
//         // Arrange
//         var bag = new SessionBag();
//         var value = new List<int> { 1, 2, 3 };
//
//         // Act
//         bag.Set(value);
//         List<int>? result = bag.Get<List<int>>();
//
//         // Assert
//         Assert.Equal(value, result);
//     }
//
//     [Fact]
//     public void CanResolveServiceProvider()
//     {
//         // Arrange
//         var serviceProvider = new TestServiceProvider();
//         var bag = new SessionBag(serviceProvider);
//
//         // Act
//         TestService? result = bag.Get<TestService>();
//
//         // Assert
//         Assert.NotNull(result);
//         _ = Assert.IsType<TestService>(result);
//     }
//
//     private sealed class TestServiceProvider : IServiceProvider
//     {
//         public object? GetService(Type serviceType) =>
//             serviceType == typeof(TestService) ? new TestService() : null;
//     }
//
//     private sealed class TestService { }
// }
