using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Morpion : MonoBehaviour {


	//public Button so, di, pr, qu;
	public Button b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b11,b12,b13,b14,b15,b16,recom;
	public GameObject gagne, perdu, nul;
	private bool onTurn = true;
	private Button[] box = new Button[17];
	private int[] valeur = new int[17];
	private int[] somme = new int[10];
	private string etatGame;
	private int nbCout = 0;
  private bool endGame = false;




	// Use this for initialization
	void Start () {
		box [1] = b1;
		box [2] = b2;
		box [3] = b3;
		box [4] = b4;
		box [5] = b5;
		box [6] = b6;
		box [7] = b7;
		box [8] = b8;
		box [9] = b9;
		box [10] = b10;
		box [11] = b11;
		box [12] = b12;
		box [13] = b13;
		box [14] = b14;
		box [15] = b15;
		box [16] = b16;

		for (int i=1; i<17;i++) {
			valeur [i] = 0;
		}

		box [1].onClick.AddListener(() => PB(1));
		box [2].onClick.AddListener(() => PB(2));
		box [3].onClick.AddListener(() => PB(3));
		box [4].onClick.AddListener(() => PB(4));
		box [5].onClick.AddListener(() => PB(5));
		box [6].onClick.AddListener(() => PB(6));
		box [7].onClick.AddListener(() => PB(7));
		box [8].onClick.AddListener(() => PB(8));
		box [9].onClick.AddListener(() => PB(9));
		box [10].onClick.AddListener(() => PB(10));
		box [11].onClick.AddListener(() => PB(11));
		box [12].onClick.AddListener(() => PB(12));
		box [13].onClick.AddListener(() => PB(13));
		box [14].onClick.AddListener(() => PB(14));
		box [15].onClick.AddListener(() => PB(15));
		box [16].onClick.AddListener(() => PB(16));

		//bval.onClick.AddListener(() => valider());

		recom.onClick.AddListener(() => recommencer());

		// color blue = Color.blue;
		// color green = Color.green;
	}

	void PB(int i) {
		if (valeur [i] ==0) {
			ColorBlock cb = box [i].colors;
			cb.normalColor = Color.blue;
			cb.highlightedColor=Color.blue;
			cb.pressedColor = Color.blue;
			box [i].colors = cb;
			valeur [i] = 1;

			turnBot();
		}

	}

	void recommencer() {
		Application.LoadLevel(Application.loadedLevel);
	}

	void turnBot() {
		onTurn = true;
		nbCout++;
		checkBoard();
		checkCondition(30);
		if (onTurn) {
			checkCondition(3);
			if (onTurn) {
        defense();
        if (onTurn) {
          placeDefault();
        }
			}
		}
		checkBoard();
		checkFinish();
		if (nbCout == 8 && endGame == false) {
			nul.SetActive (true);
		}

	}

	void checkBoard() {
		somme [0] = valeur [1]+valeur [2]+valeur [3]+valeur [4];
		somme [1] = valeur [5]+valeur [6]+valeur [7]+valeur [8];
		somme [2] = valeur [9]+valeur [10]+valeur [11]+valeur [12];
		somme [3] = valeur [13]+valeur [14]+valeur [15]+valeur [16];

		somme [4] = valeur [1]+valeur [5]+valeur [9]+valeur [13];
		somme [5] = valeur [2]+valeur [6]+valeur [10]+valeur [14];
		somme [6] = valeur [3]+valeur [7]+valeur [11]+valeur [15];
		somme [7] = valeur [4]+valeur [8]+valeur [12]+valeur [16];

		somme [8] = valeur [1]+valeur [6]+valeur [11]+valeur [16];
		somme [9] = valeur [4]+valeur [7]+valeur [10]+valeur [13];
	}

  void checkCondition(int val) {
    if (somme [0] == val) {
      for (int i=1;i<5;i++) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [1] == val) {
      for (int i=5;i<9;i++) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [2] == val) {
      for (int i=9;i<13;i++) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [3] == val) {
      for (int i=13;i<17;i++) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [4] == val) {
      for (int i=1;i<14;i+=4) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [5] == val) {
      for (int i=2;i<15;i+=4) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [6] == val) {
      for (int i=3;i<16;i+=4) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [7] == val) {
      for (int i=4;i<17;i+=4) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [8] == val) {
      for (int i=1;i<17;i+=5) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
    else if (somme [9] == val) {
      for (int i=4;i<14;i+=3) {
        if (valeur [i] == 0) {
          colorisVert(i);
        }
      }
    }
  }

  void defense() {
    if (somme [0] == 2) {
      if (valeur [1] == 0) {
        colorisVert(1);
      }
      else if (valeur [4] == 0) {
        colorisVert(4);
      }
      else {
        colorisVert(2);
      }
    }
    else if (somme [1] == 2) {
      if (valeur [5] == 0) {
        colorisVert(5);
      }
      else {
        colorisVert(8);
      }
    }
    else if (somme [2] == 2) {
      if (valeur [10] == 0) {
        colorisVert(10);
      }
      else if (valeur [11] == 0) {
        colorisVert(11);
      }
      else {
        colorisVert(9);
      }
    }
    else if (somme [3] == 2) {
      if (valeur [13] == 0) {
        colorisVert(13);
      }
      else if (valeur [16] == 0) {
        colorisVert(16);
      }
      else {
        colorisVert(14);
      }
    }
    else if (somme [4] == 2) {
      if (valeur [1] == 0) {
        colorisVert(1);
      }
      else if (valeur [13] == 0) {
        colorisVert(13);
      }
      else {
        colorisVert(5);
      }
    }
    else if (somme [5] == 2) {
      if (valeur [2] == 0) {
        colorisVert(2);
      }
      else {
        colorisVert(14);
      }
    }
    else if (somme [6] == 2) {
      if (valeur [3] == 0) {
        colorisVert(3);
      }
      else {
        colorisVert(15);
      }
    }
    else if (somme [7] == 2) {
      if (valeur [16] == 0) {
        colorisVert(16);
      }
      else if (valeur [4] == 0) {
        colorisVert(4);
      }
      else {
        colorisVert(8);
      }
    }
    else if (somme [8] == 2) {
      if (valeur [1] == 0) {
        colorisVert(1);
      }
      else {
        colorisVert(16);
      }
    }
    else if (somme [9] == 2) {
      if (valeur [13] == 0) {
        colorisVert(13);
      }
      else if (valeur [4] == 0) {
        colorisVert(4);
      }
      else {
        colorisVert(2);
      }
    }
  }

	void placeDefault() {
		if (valeur [6] == 0) {
			colorisVert(6);
		}
		else if (valeur [7] == 0) {
			colorisVert(7);
		}
		else if (valeur [10] == 0) {
			colorisVert(10);
		}
		else if (valeur [11] == 0) {
			colorisVert(11);
		}
		else if (valeur [1] == 0) {
			colorisVert(1);
		}
		else if (valeur [4] == 0) {
			colorisVert(4);
		}
		else if (valeur [13] == 0) {
			colorisVert(13);
		}
		else if (valeur [16] == 0) {
			colorisVert(16);
		}
		else if (valeur [2] == 0) {
			colorisVert(2);
		}
		else if (valeur [5] == 0) {
			colorisVert(5);
		}
		else if (valeur [3] == 0) {
			colorisVert(3);
		}
		else if (valeur [8] == 0) {
			colorisVert(8);
		}
		else if (valeur [9] == 0) {
			colorisVert(9);
		}
		else if (valeur [14] == 0) {
			colorisVert(14);
		}
		else if (valeur [12] == 0) {
			colorisVert(12);
		}
		else {
			colorisVert(15);
		}
	}

	void checkFinish() {
		for (int i=0;i<10;i++) {
			if (somme [i] == 40) {
				perdu.SetActive (true);
        endGame = true;
			}
			else if (somme [i] == 4) {
				gagne.SetActive (true);
        endGame = true;
			}
		}
	}

	void colorisVert(int i) {
		ColorBlock cb = box [i].colors;
		cb.normalColor = Color.green;
		cb.highlightedColor=Color.green;
		cb.pressedColor = Color.green;
		box [i].colors = cb;
		valeur [i] = 10;
		onTurn = false;
	}

	void Update () {

	}

}
