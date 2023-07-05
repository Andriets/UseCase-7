using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase_7.StudentTask;

namespace UseCase_7Tests
{
    public class StudentTests
    {
        private StudentConverter _studentConverter;

        public StudentTests()
        {
            _studentConverter = new StudentConverter();
        }

        [Theory]
        [InlineData(21, 91, true, false, false)]
        [InlineData(20, 91, false, true, false)]
        [InlineData(20, 90, false, false, true)]
        [InlineData(20, 70, false, false, false)]
        public void ConvertStudents_ReturnsCorrectList(int age, int Grade, bool expectedHonorRoll, bool expectedExceptional, bool expectedPassed)
        {
            // Arrange
            var entry = new List<Student>
            {
                new Student
                {
                    Age = age,
                    Grade = Grade
                }
            };

            // Act
            var result = _studentConverter.ConvertStudents(entry);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.First());
            Assert.Equal(result.First().HonorRoll, expectedHonorRoll);
            Assert.Equal(result.First().Exceptional, expectedExceptional);
            Assert.Equal(result.First().Passed, expectedPassed);
        }

        [Fact]
        public void ConvertStudents_ReturnsAnEmptyArray()
        {
            // Arrange
            var entry = new List<Student>();

            // Act
            var result = _studentConverter.ConvertStudents(entry);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ConvertStudents_ThrowsAnError()
        {
            // Arrange
            List<Student> entry = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => _studentConverter.ConvertStudents(entry));
        }
    }
}
