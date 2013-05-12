// updates to see if raycast returns a hit and checks that hit name for advancement or exit.
function Update()
{
    //check if the left mouse has been pressed down this frame
    if (Input.GetMouseButtonDown(0))
    {
        //empty RaycastHit object which raycast puts the hit details into
        var hit : RaycastHit;
        //ray shooting out of the camera from where the mouse is
        var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
 		// checks the hit if so tells us the name in debug and then checks what to do with that name.
        if (Physics.Raycast(ray, hit))
        {
        Debug.Log(hit.collider.name);
        // starts game.
        if (hit.collider.name == "ControllerGuide")
         {
         	Application.LoadLevel(3);
         }
         // loads menus.
         if (hit.collider.name == "howtoplay")
         {
         	Application.LoadLevel(4);
         } 
         if (hit.collider.name == "credits")
         {
         	Application.LoadLevel(5);
         } 
         if (hit.collider.name == "back")
         {
         	Application.LoadLevel(0);
         } 
         // exits game 
         if (hit.collider.name == "exit")
         {
         	Application.Quit();
         }   
        }
    }
}