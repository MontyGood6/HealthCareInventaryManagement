namespace Healthcare.InventoryManagement.Domain.Entity
{

    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }

        public string Name { get; private set; }

        public int RoleId { get;  private set; }

        public ICollection<UserRole> UserRoles { get; set; }


        public UserRole Role { get; set; } 



        public string PasswordHash { get; private set; } = string.Empty;

        public User(Guid id, string email, string name, string passwordHash, int roleId)
        {
            Id = id;
            Email = email;
            Name = name;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }
    }

}
