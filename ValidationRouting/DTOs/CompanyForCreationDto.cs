namespace ValidationRouting.DTOs
{
    public class CompanyForCreationDto : CompanyForManipulationDto
    {
        public IEnumerable<EmployeeForManipulationDto> Employees { get; set; }
    }
}
