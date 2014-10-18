String processingString = "";
 

// All Examples Written by Casey Reas and Ben Fry

// unless otherwise stated.

int num = 60;

float mx[] = new float[num];

float my[] = new float[num];


void setup() 

{

  size(300, 230);

  smooth();

  // set line color to black
  stroke(0);
  // and the width
  strokeWeight(4);
}


void draw() 

{
  if (mousePressed) {
	// draw line between previous and new mouse coordinates
	line(pmouseX,pmouseY, mouseX,mouseY);
  }
}

void keyPressed() 
{
    if (key == 's' || key == 'S') saveFrame("myScreenshots.png");
    if (key == DELETE || key == BACKSPACE) setup();
}
