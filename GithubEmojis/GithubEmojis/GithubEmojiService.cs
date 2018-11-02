using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GithubEmojis {
    public class Emoji {
        public string Key {
            get;
            set;
        }
        public string Url {
            get;
            set;
        }
    }

    public class GithubEmojiService : IGithubEmojiService {
        public IList<Emoji> GetEmojisFrom(string content) {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            var results = new List<Emoji>();

            foreach (var key in dictionary.Keys) {
                if (string.IsNullOrWhiteSpace(key)) { continue; }

                results.Add(new Emoji {
                    Key = key,
                    Url = dictionary[key]
                });
            }

            return results;
        }

    }
}
