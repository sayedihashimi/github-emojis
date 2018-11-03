using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace GithubEmojis {

    public class GithubEmojiService : IGithubEmojiService {
        const string GithubEmojiUrl = "https://api.github.com/emojis";
        private readonly HttpClient _httpClient;
        private IList<Emoji> _emojis;

        public GithubEmojiService() {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "sayedihashimi-github-emojis");
        }

        public async Task<IList<Emoji>> GetEmojis() {
            if(_emojis == null || _emojis.Count <= 0) {
                var emojiStr = await _httpClient.GetStringAsync(GithubEmojiUrl);
                try {
                    _emojis = GetEmojisFrom(emojiStr);
                }
                catch(Exception ex) {
                    System.Console.WriteLine($"error: {ex.ToString()}");
                }
            }

            return _emojis;
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
