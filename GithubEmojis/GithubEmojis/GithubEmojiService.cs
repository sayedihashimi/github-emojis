using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;

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
        const string GithubEmojiUrl = "https://api.github.com/emojis";
        private readonly HttpClient _httpClient;

        public GithubEmojiService() {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "sayedihashimi-github-emojis");
        }

        public async Task<IList<Emoji>> GetEmojis() {
            var emojiStr = await _httpClient.GetStringAsync(GithubEmojiUrl);
            return GetEmojisFrom(emojiStr);
        }

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
