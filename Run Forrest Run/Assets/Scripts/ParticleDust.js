#pragma strict

var dust : Transform;

function Update () {

	 if(Input.GetKeyDown("space"))
     {

		Instantiate(dust, transform.position, transform.rotation);

     }
}
