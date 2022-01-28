using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // command to add reference to a project : dotnet add reference ../../src/GradeBook/GradeBook.csproj 
            // Arrange 
            var book = new Book("");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            Statistics result = book.getStatistics();

            // Assert
            Assert.Equal(result.High, 90.5, 1);
            Assert.Equal(result.Low, 77.3, 1);
            Assert.Equal(result.Average, 85.63, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}