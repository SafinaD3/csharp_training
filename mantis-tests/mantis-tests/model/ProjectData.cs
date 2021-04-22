using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData //: IEquatable<ProjectData>, IComparable<ProjectData>
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
    }
}
