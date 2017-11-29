using System.Collections.Generic;
using SmartSocialServices.Objects;

namespace SmartSocialServices.Messaging.Response
{
    public class ConversationStreamResponse: BaseResponse
    {
        public List<ConversationStreamObject> conversationStreamObjects { get; set; }

        public ConversationStreamResponse() {
            conversationStreamObjects = new List<ConversationStreamObject>();
        }
    }
}
