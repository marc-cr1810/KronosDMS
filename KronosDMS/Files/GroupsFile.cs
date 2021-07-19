﻿using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Files
{
    public class GroupsFile
    {
        public Dictionary<string, Group> Groups;

        public GroupsFile()
        {
            if (File.Exists(@"data/UserGroups.json"))
                Groups = JsonConvert.DeserializeObject<Dictionary<string, Group>>(File.ReadAllText(@"data/UserGroups.json"));
            if (Groups is null)
                Groups = new Dictionary<string, Group>();

            // Ensure the Administrator group exists
            if (!Groups.ContainsKey("Administrator"))
            {
                Groups.Add("Administrator", new Group(255, new List<string>() { "*" }));
            }
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

        public string Get(string id)
        {
            if (id != "")
            {
                Dictionary<string, Group> result = new Dictionary<string, Group>();
                if (Groups.ContainsKey(id))
                    result.Add(id, Groups[id]);
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(Groups);
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Groups, Formatting.Indented);
            File.WriteAllText(@"data/UserGroups.json", output);
        }
    }
}
