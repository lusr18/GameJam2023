using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

public class OpenAIController : MonoBehaviour
{
    public TMP_Text textField;
    public TMP_InputField inputField;
    public Button okButton;

    private readonly string apiKey = "INSERT SECRET API KEY HERE";

    private OpenAIAPI api; //api wrapper
    private List<ChatMessage> messages; //accumulate messages
    
    void Start()
    {
        api = new OpenAIAPI(apiKey);
        StartConversation();
        okButton.onClick.AddListener(() => GetResponse());
    }

    private void StartConversation()
    {
        messages = new List<ChatMessage> {
            new ChatMessage(ChatMessageRole.System, "You are the mean boss running a scamming company. You keep your responses short and to the point. You think you are better than everyone and are evil. You are only less mean if the person you are talking to did a lot of scams successfully for your scamming company and has earned your trust."),

        };

        inputField.text = "";
        string startString = "You were kidnapped here by the mean boss to scam for him, earn his trust or argue with him!";
        textField.text = startString;
        Debug.Log(startString);
    }

    private async void GetResponse()
    {
        if(inputField.text.Length < 1)
        {
            return;
        }

        //disable ok while API processing message
        okButton.enabled = false;

        //fill the user message from the input field
        ChatMessage userMessage = new ChatMessage();
        userMessage.Content = inputField.text;
        if (userMessage.Content.Length > 100)
        {
            // limit messages to 100 characters
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("({0}: {1}", userMessage.rawRole, userMessage.Content));

        // Add message to list
        messages.Add(userMessage);

        //Update textfield with user message
        textField.text = string.Format("You: {0}", userMessage.Content);

        //Clear input field
        inputField.text = "";

        //Send entire chat to openai to get next message
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1, //closer to 0 == GPT more confidence in own response
            MaxTokens = 50,
            Messages = messages
        });

        //Get response message
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.rawRole, responseMessage.Content));

        //add response to list
        messages.Add(responseMessage);

        //update text field
        textField.text = string.Format("You: {0}\n\nGuard: {1}", userMessage.Content, responseMessage.Content);

        //re-enable ok button
        okButton.enabled = true;
    }
}