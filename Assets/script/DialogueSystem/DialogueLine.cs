using System.Collections;
using UnityEngine;
using UnityEngine.UI;


    public class DialogueLine : MonoBehaviour
    {
        private Text textHolder;

        public string[] textInput;

        public float delay;




        private void Awake()
        {

            textHolder = GetComponent<Text>();

            delay = 0.3f;

            StartCoroutine(WriteText());
        }

        protected IEnumerator WriteText()
        {
           foreach(string sentence in textInput)
            {
                    for(int i = 0; i < sentence.Length; i++)
                    {
                        textHolder.text += sentence[i];

                        yield return new WaitForSeconds(delay);
                    }
                
               textHolder.text = " ";
                yield return new WaitForSeconds(2);

                
            }
         

            

        }
    }
