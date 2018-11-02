using System;
using System.Collections.Generic;

namespace GithubEmojis {
    public interface IGithubEmojiService {
        IList<Emoji> GetEmojisFrom(string content);
    }
}
