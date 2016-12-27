using System;
using System.Linq;
using DemoProject.ServiceFabric.Common.Data;
using DemoProject.ServiceFabric.CourseDatabase.Models;
using DemoProject.ServiceFabric.CourseWebApi.Controllers;
using NUnit.Framework;

namespace DemoProject.ServiceFabric.CourseWebApiTests.Controllers
{
    [TestFixture]
    public class CourseControllerTests
    {
        private readonly string _courseTestName = "TestCouse" + DateTime.Now;
        private readonly string _courseSkill = "C#";

        private IRepository<Course> Repository { get; }
        private CoursesController CourseController { get; }

        public CourseControllerTests()
        {
            Repository = new MongoDbRepository<Course>();
            CourseController = new CoursesController(Repository);
        }

        [Test]
        public void CreateNewCourse_ShouldCreateItemInDb()
        {
            var response = CourseController.Post(new Course(_courseTestName, _courseSkill));
            Assert.True(response.IsSuccessStatusCode);
            var createdCourses = Repository.SearchFor(x => x.Name == _courseTestName).ToList();
            Assert.True(createdCourses.Count == 1, "Should create only one course");
            var createdCourse = createdCourses.First();
            Assert.True(createdCourse.Skill == _courseSkill, "Should create course with correct skill value");
            
            Assert.True(
                !string.IsNullOrWhiteSpace(createdCourse.Id), "Should create valid ObjectId");

            Repository.Delete(createdCourse.Id);
        }


        [Test]
        public void CreateNewCourseWithName_ShouldCreateItemInDbAndGenerateSkill()
        {
            var courseController = new CoursesController(Repository);
            var response = courseController.Post(new Course(_courseTestName));
            Assert.True(response.IsSuccessStatusCode);
            var createdCourse = Repository.SearchFor(x => x.Name == _courseTestName).First();
            Assert.True(createdCourse.Skill == _courseTestName,
                "Should create course with same skill as currenct course name");
            Repository.Delete(createdCourse.Id);
        }

        [Test]
        public void DeleteCourse_ShouldRemoveItem()
        {
            //prepare
            var courseController = new CoursesController(Repository);
            courseController.Post(new Course(_courseTestName));

            var createdCourse = Repository.SearchFor(x => x.Name == _courseTestName).First();

            var response = courseController.Delete(createdCourse.Id);
            Assert.True(response.IsSuccessStatusCode);
            var removedCoursesCount = Repository.SearchFor(x => x.Name == _courseTestName).Count();
            Assert.True(removedCoursesCount == 0, "Course should be removed");
        }

        [Test]
        public void GetCourseById_ShouldReturnCourse()
        {
            //prepare
            var courseController = new CoursesController(Repository);
            courseController.Post(new Course(_courseTestName));

            var createdCourse = Repository.SearchFor(x => x.Name == _courseTestName).First();
            var response = courseController.Get(createdCourse.Id);

            Assert.True(response != null);
            Assert.True(response.Name == _courseTestName);
            Repository.Delete(createdCourse.Id);
        }

        [Test]
        public void GetCourses_ShouldReturnList()
        {
            //prepare
            var courseController = new CoursesController(Repository);
            courseController.Post(new Course(_courseTestName));

            var createdCourse = Repository.SearchFor(x => x.Name == _courseTestName).First();
            var response = courseController.Get();

            Assert.True(response.Any(x => x.Name == _courseTestName));
            Repository.Delete(createdCourse.Id);
        }


        [Test]
        public void UpdateCourse_ShouldUpdateSkillAndName()
        {
            //prepare
            var courseController = new CoursesController(Repository);
            courseController.Post(new Course(_courseTestName));

            var createdCourse = Repository.SearchFor(x => x.Name == _courseTestName).First();
            createdCourse.Skill = _courseSkill;
            var response = courseController.Put(createdCourse);

            Assert.True(response.IsSuccessStatusCode);
            Assert.True(createdCourse.Skill == _courseSkill, "Should update course with new skill");
            Repository.Delete(createdCourse.Id);
        }
    }
}