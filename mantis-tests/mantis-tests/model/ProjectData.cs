using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {
        }

        public ProjectData(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ProjectData> GetAll()
        {
            using (BugtrackerDB db = new BugtrackerDB())
            {
                return (from g in db.Projects select g).ToList();
            }
        }

        public int CompareTo(ProjectData other)
        {
            if (other is null)
            {
                return 1;
            }
            if (Name.CompareTo(other.Name) == 0)
            {
                return Description.CompareTo(other.Description);
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this.Name, other.Name))
            {
                if (Object.ReferenceEquals(this.Description, other.Description))
                {
                    return true;
                }
                return Description == other.Description;
            }
            return Name == other.Name;
        }
    }
}
