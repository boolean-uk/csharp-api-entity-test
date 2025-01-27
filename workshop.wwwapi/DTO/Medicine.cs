namespace workshop.wwwapi.DTO
{
    public record MedicinePost(string Name, string Category);
    public record MedicineView(int Id, string Name, string Category);
    public record MedicineInternal(int Id, string Name, string Category);
}
