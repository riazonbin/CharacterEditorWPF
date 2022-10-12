using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class MatchInfo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime MatchTime { get; set; }

        public List<CharacterInfo>? FirstTeam {get; set;}

        public List<CharacterInfo>? SecondTeam { get; set; }

        public MatchInfo(List<CharacterInfo> firstTeam, List<CharacterInfo> secondTeam)
        {
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
            MatchTime = DateTime.Now;
        }
    }
}
