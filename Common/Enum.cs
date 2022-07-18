namespace Kensa.Common
{
    public static class Enum
    {
        public enum UserType
        {
            Admin,
            User
        }
        public enum PostStatus
        {
            Draft,
            PendingApproval,
            Active,
            Paused,
        }
        public enum JobStatus
        {
            Created,
            Received,
            Doing,
        }
    }
}
