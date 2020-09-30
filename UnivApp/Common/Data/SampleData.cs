using ContosoUniversity.Data.DTO;
using UnivApp.Common.DTO;
using System.Collections.Generic;

namespace UnivApp.Common.Data
{
    public class SampleData
    {
        public List<EnrollmentDTO> Enrollments { get; set; }
        public List<CourseDTO> Courses { get; set; }
        public List<CourseAssignmentsDTO> CourseAssignments { get; set; }
        public List<DepartmentDTO> Departments { get; set; }
        public List<StudentDTO> Students { get; set; }
        public List<OfficeAssignmentDTO> OfficeAssignments { get; set; }
        public List<InstructorDTO> Instructors { get; set; }
        public bool SaveToExternalFile { get; set; }
    }
}
