#pragma strict

var doink : Transform;
var blood : Transform;


function OnControllerColliderHit (info : ControllerColliderHit) {

	if (info.gameObject.tag == 'Enemy') {
		var dumb = info.gameObject;

		Instantiate(doink, transform.position, transform.rotation);

		//yield(3);
		Destroy (dumb);

	}else if (info.gameObject.tag == 'Ai') {

		Instantiate(blood, transform.position, transform.rotation);

		Destroy(this.gameObject);
	}

}


