using System;
using Xunit;

namespace GradeBook.Tests
{
    // Defining Delegate for example logging
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        // Just to test multi cast delegate
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            /*Delegate demonstration*/

            // Declare a delegate variable
            WriteLogDelegate log;
            // Two means of pointing log the delegate function
            // log = new WriteLogDelegate(ReturnMessage);
            log = ReturnMessage;

            // Multicast delegate (chaining delegate functions)
            log += ReturnMessage2;

            var result = log("Hello");

            Assert.Equal(2, count);

        }

        // Defining a method the delegate can point to
        string ReturnMessage(string message)
        {
            count += 1;
            return message;
        }

        string ReturnMessage2(string message)
        {
            count += 1;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueType()
        {
            string name = "edward";
            MakeUppercase(name);
            Assert.Equal("edward", name);
        }

        private void MakeUppercase(string arg1)
        {
            arg1.ToUpper();
        }


        [Fact]
        public void ValueTypeAlsoPassedByValue()
        {
            var x = GetInt();
            setInt(ref x);
            Assert.Equal(43, x);

        }

        private void setInt(ref int x)
        {
            x = 43;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassedByref()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(out Book book, string name)
        {
            /*
            Instead of ref we can use out. But we are force to initialised the out parameter 
            else there will be an error
            */
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReferences()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObjcts()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }


        private Book GetBook(string bookName)
        {
            return new Book(bookName);
        }
    }
}