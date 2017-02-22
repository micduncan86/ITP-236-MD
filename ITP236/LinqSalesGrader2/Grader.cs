using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LinqSalesGrader2;

using static System.Configuration.ConfigurationSettings;

namespace LinqSalesProjectGrader2
{
    public class Grader
    {
        public ProjectData sampleData;
        XDocument projectXml;
        public List<Topic> topics { get; private set; }
        private ProjectTest tests { get; set; }
        public string ProjectName { get; private set; }
        public string StudentName { get; private set; }
        public int TotalGrade { get; private set; }
        public int TotalValue { get; private set; }
        public decimal GradePercentage { get; private set; }

        public enum Project
        {
            Linq,
            EntityFramework
        }
        public Grader(Project project)
        {
            sampleData = new ProjectData(project);
            ProjectName = sampleData.ProjectName;
            projectXml = XDocument.Load("XML/LinqSales.xml");
            topics = BuildTestPlan(projectXml);
            tests = new ProjectTest(sampleData, topics);
            StudentName = tests.StudentName;
            TotalGrade = topics.Sum(t => t.TotalGrade);
            TotalValue = topics.Sum(t => t.TotalValue);
            GradePercentage = TotalValue > 0 ? TotalGrade / (decimal)TotalValue : 0m;
        }

        private List<Topic> BuildTestPlan(XDocument testPlan)
        {
            var topics = (from topic in projectXml.Descendants("Topic")
                select new Topic(topic.Attribute("Name").Value)
                {
                    Tests = (from test in topic.Descendants("Test")
                             select new Test()
                             {
                                 Name = test.Attribute("Name").Value,
                                 Value = Convert.ToInt32(test.Attribute("Value").Value),
                                 Method = test.Attribute("Method").Value
                             }).ToList()
                }).ToList();
            return topics;
        }
    }
    public class Topic
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public List<Test> Tests { get; set; }
        public int TotalGrade => Tests.Sum(t => t.Grade);
        public int TotalValue => Tests.Sum(t => t.Value);
        public decimal GradePercentage => TotalValue == 0 ? 0 : (decimal) TotalGrade/(decimal) TotalValue;
        public Topic () : this("Missing") { }
        public Topic(string Name)
        {
            this.Name = Name;
            Tests = new List<Test>();
        }
    }
    public class Result
    {
        public int Id { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
    }
    public class Test
    {
        public enum TestType
        {
            Class,
            Constructor,
            Constant,
            Property,
            Method,
            Functional
        }
        public TestType Type { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Expected { get; set; }
        public string Actual { get; set; }
        public int Value { get; set; }
        public int Grade { get; set; }
        public List<Result> StudentResults;
        public List<Result> AnswerResults;
        public string[] Resultnames;
        public string Method { get; set; }
        public Test() : this("Missing", 0) { }
        public Test(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
            StudentResults = new List<Result>();
            AnswerResults = new List<Result>();
        }
    }

}
