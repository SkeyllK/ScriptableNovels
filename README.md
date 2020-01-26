# ScriptableNovels
Simple visual novel game sample for Unity.
Can display a character and background images and text by ScriptableObject. 
I hope you can customize this sample easily!

The function for now.
* Create plots by ScriptableObject (Can set data on Unity inspecter).
* Display one character image on three position (left, center and right of screen).
* Display text by the four way (Title, conversation, quote, discription).

I may add other function such a select command for a branch story or a simple action game in novel, but at now this is just for displaying a text and picture.


## Instructions
1. Import this project or StoryData.cs and StoryManager.cs in Assets/Script/*.
2. Create stroy plot from Create/Story/Createplot of Project menu into Resources/StoryPlot/*. (Can change this path if fixing load path in StoryManager.cs)
<img src="https://user-images.githubusercontent.com/50002207/73133925-d6a7ec00-4072-11ea-9898-4dc804841e6b.png">

3. Make asset's name StoryN(int numbe) and then set story data. (Get this file from Resources by int number)
<img src="https://user-images.githubusercontent.com/50002207/73133970-db20d480-4073-11ea-8452-7166b0e3d497.png">

 * Size: The length of this story
 * Scene text: Displayed text
 * Text role: Change the position and size of text
 * Model: Displayed image (*1)
 * Model Number: Change the picture of model (*2)
 * Speaker: Displayed the name avobe conversation
 * ModelPos: Change the model position
 * Field: Displayed background image (*1)
 * Field Number: Change the picture of field (*2)
 
*1 Need to set some name in StoryData.cs in after use this script.

<img src="https://user-images.githubusercontent.com/50002207/73134092-972ecf00-4075-11ea-82b0-03adca62f8ac.png">

*2 If a project need not change the image type (Ex. angry face, joy face), remove this part from StoryData.cs.

4. Import a image into Resource/StoryImage/*.

5. Attach to a object in hierarchy and set some ui.
6. Add event trriger to the field image and regsiter LoadNextPart of StoryManager.cs to PointerUP event.

<img src="https://user-images.githubusercontent.com/50002207/73134180-f3462300-4076-11ea-92bc-d7f4a1f736bf.png">


Use http://www.yutorilife.com/ 's image in this project.
