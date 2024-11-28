namespace WebService.Entities
{
    public class ReqDTO
    {
        public int ReqId { get; set; }  // req_id
        public string JobTitle { get; set; }  // job_title
        public int DeptId { get; set; }  // dept_id
        public int ProjectId { get; set; }  // project_id
        public string HiringManager { get; set; }  // hiring_manager
        public int Positions { get; set; }  // positions
        public int Duration { get; set; }  // duration
        public DateTime StartDate { get; set; }  // start_date
        public DateTime EndDate { get; set; }  // end_date
        public string EmployeeType { get; set; }  // employee_type
        public string ReplacementEmp { get; set; }  // replacement_emp
        public string Competency { get; set; }  // competency
        public string EmploymentType { get; set; }  // employment_type
        public string LocationType { get; set; }  // location_type
        public int LocationId { get; set; }  // location_id
        public int WorkingHours { get; set; }  // working_hours
        public string RolesAndResponsibility { get; set; }  // roles_and_responsibility
        public string MinQualification { get; set; }  // min_qualification
        public string RequiredSkills { get; set; }  // required_skills
        public string PreferredSkills { get; set; }  // preferred_skills
        public string Specialization { get; set; }  // specialization
        public int TotalExp { get; set; }  // total_exp
        public int RelevantExp { get; set; }  // relevant_exp
        public string CTQ { get; set; }  // CTQ
        public string Benefits { get; set; }  // benefits
        public string SpecialRequirements { get; set; }  // special_requirements
        public decimal EstimatedBudget { get; set; }  // estimated_budget
        public string References { get; set; }  // references
        public string SourcingManager { get; set; }  // sourcing_manager
        public int RateCardId { get; set; }  // rate_card_id
        public string Status { get; set; }  // status
        public string Comments { get; set; }  // comments
        public string CreatedBy { get; set; }  // created_by
        public DateTime CreatedDate { get; set; }  // created_date
        public string ModifiedBy { get; set; }  // modified_by
        public DateTime ModifiedDate { get; set; }  // modified_date
    }
}
