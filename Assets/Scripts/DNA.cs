using UnityEngine;
using System.Collections;
/*has everything a plant needs to grow itself
 * 
 * num stems
 * color flowers r g and b
 * color leaves, r g and b (constrained to shades of green)
 * 
 * number leaves
 * number flowers
 * 
 * location leaves (dominent inside stem)
 * location flowers (dominent tips of stems)
 * 
 * shape leaves
 * shape flowers
 * 
 * size leaves
 * size flowers
 * 
 */ 
public class DNA {
	public int numStems = 0;
	public int maxStems = 2;

	public DNA(int maxStems){
		this.maxStems = maxStems;
		this.numStems = 0;
	}

	public static DNA randomDNA(){
		return new DNA (Random.Range(2,30));
	}
}
