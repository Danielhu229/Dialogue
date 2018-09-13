using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/Graph", order = 0)]
    public class DialogueGraph : NodeGraph {
        public Chat current = null;

        public void Restart() {
            //Find the first DialogueNode without any inputs. This is the starting node.
            current = nodes.Find(x => x is Chat && x.Inputs.All(y => !y.IsConnected)) as Chat;
        }

        //public void Next()
        //{
        //    var port = current.GetOutputPort("output");

        //    if (port == null) return;
        //    for (int i = 0; i < port.ConnectionCount; i++)
        //    {
        //        NodePort connection = port.GetConnection(i);
        //        current = connection.node as Chat;
        //    }
        //}

        public Chat AnswerQuestion(int i) {
            current.AnswerQuestion(i);
            return current;
        }
    }
}