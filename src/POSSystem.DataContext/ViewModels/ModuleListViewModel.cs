namespace POSSystem.DataContext.ViewModels;

public class ModuleListViewModel
{
	public int? ModuleId { get; set; }

	public string? ModuleName { get; set; }

	public string? ModuleIcon { get; set; }

	public string? ModuleDescription { get; set; }

	public string? Createdby { get; set; }

	public DateTime? CreatedDate { get; set; }

	public string? ModifiedBy { get; set; }

	public DateTime? ModifiedDate { get; set; }

	public int? ParentId { get; set; }

	public int? RoleId { get; set; }

	public string? RoleName { get; set; }

	public string? ContentTemplate { get; set; }

	public List<ModuleListViewModel> ChildModuleLists { get; set; } = new();
}
