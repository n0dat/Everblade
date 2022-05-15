using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMessages : MonoBehaviour {
	
	// holding different NPC responses
	
	//
	// quest rewards
	//
	public string[] rewards = {" 10 Rubies ", " Fire Sword ", " 1 Ruby / kill "}; // this is depracated
	
	//
	// NPC quest dialogue
	//
	public string[] npcDialogue = {"Help!\nA band of demon babies have been terrorizing our town!",
								   "Hello traveller.\n\nCould you take out the large Orc in Apalleco Cave?",
								   "Hey! I have locked myself out of my house. Some Orcs in the Northwest took the key!"
								  };
	
	//
	// proposal quest messages
	//
	// no idea why this needs to be serialized, but if fixed it from showing empty in game
	//
	[SerializeField]
	public string[] proposalMessages = {"Could you take them out for:\n\n10 Rubies?",
										"\nIf you complete this task you will get a Fire Sword.",
										"\nCould you get the key to my house back for me?"
									   };
	
	//
	// thanking player messages
	//
	public string[] thankMessages = {"Thank you!\n\nMay god bless your soul.",
									 "Our thoughts and prayers are with you.\n\nBe safe.",
									 "\nGood luck!"
									 };
	
	//
	// deny quest messages
	//
	public string[] denyMessages = {"Don't sweat it.\n\nMaybe someone else can save us.",
									"If you change your mind, don't hesitate to come talk to me again.",
									"Maybe my day of reckining has finally come . . ."
									};
	
	//
	// quest incomplete message
	//
	public string incompleteMessage = "You have not completed this quest yet.\nPlease come back when you do for a reward!";
		
	//
	// comeback to npc
	//
	public string comebackMessage = "You came back!\n\nIt sure is a lovely day.";
	
	//
	// thank for completion message
	//
	public string[] completeMessage = {"Thank you for saving us!\nMay God have mercy on your soul.",
									   "Thank you for saving me!\nMay God have mercy on your soul.",
									   "Thank you for saving us!\nMay God have mercy on your soul."
									  };

}
