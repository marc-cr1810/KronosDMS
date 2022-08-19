using KronosDMS.Objects;
using KronosDMS.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS.Files
{
    public class GroupsFile
    {
        public Dictionary<string, Group> Groups;

        public int MAX_RESULTS = 100;

        public GroupsFile()
        {
            if (File.Exists(@"data/UserGroups.json"))
                Groups = JsonConvert.DeserializeObject<Dictionary<string, Group>>(File.ReadAllText(@"data/UserGroups.json"));
            if (Groups is null)
                Groups = new Dictionary<string, Group>();

            // Ensure the Administrator and Defaut group exists
            if (!Groups.ContainsKey("Administrator"))
            {
                Groups.Add("Administrator", new Group(255, new List<string>() { "*" }));
            }
            if (!Groups.ContainsKey("Default"))
            {
                Groups.Add("Default", new Group(0, new List<string>()));
            }
        }

        public bool Add(string json)
        {
            GroupData data = JsonConvert.DeserializeObject<GroupData>(json);

            try
            {
                return Add(data.Name, data.Group);
            }
            catch { return false; }
        }

        public bool Add(string name, int level, List<string> permissions)
        {
            if (Groups.ContainsKey(name))
                return false;
            Group group = new Group(level, permissions);
            Groups.Add(name, group);
            Write();
            return true;
        }

        public bool Add(string name, Group group)
        {
            // Check if the group already exists
            if (Groups.ContainsKey(name))
                return false;

            Groups.Add(name, group);
            Write();
            return true;
        }

        public string Search(string name, string level, string id = "")
        {
            Dictionary<string, Group> result = new Dictionary<string, Group>();
            if (id != "")
            {
                if (Groups.ContainsKey(id))
                    result.Add(id, Groups[id]);
                return JsonConvert.SerializeObject(result);
            }

            int numResults = 0;
            foreach (KeyValuePair<string, Group> group in Groups)
            {
                string n = group.Key;
                int l = level != "" ? int.Parse(level) : -256;
                Group g = group.Value;
                if (n.ToUpper().Contains(name.ToUpper()) &&
                    (g.Level == l || l == -256))
                {
                    result.Add(group.Key, group.Value);
                    numResults++;
                    if (numResults == MAX_RESULTS)
                        break;
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public bool Remove(string id)
        {
            if (!Groups.ContainsKey(id))
                return false;
            Groups.Remove(id);
            Write();
            return true;
        }

        public bool Set(string json)
        {
            GroupData data;
            try
            {
                data = JsonConvert.DeserializeObject<GroupData>(json);
            }
            catch { return false; }

            // Check if the group does not exist
            if (!Groups.ContainsKey(data.Name))
                return false;

            Groups[data.Name] = data.Group;
            Write();
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Groups, Formatting.Indented);
            File.WriteAllText(@"data/UserGroups.json", output);
        }
    }
}
