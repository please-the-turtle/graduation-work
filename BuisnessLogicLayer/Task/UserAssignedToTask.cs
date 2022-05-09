namespace BuisnessLogicLayer
{
    public partial class UserAssignedToTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public TimeSpan? SpentTime { get; set; }

        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
