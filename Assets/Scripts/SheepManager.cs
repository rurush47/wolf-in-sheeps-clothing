using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
	[Range(1, 200)] 
	public int sheepCount = 20;
	public GameObject sheepPrefab;
	public GameObject plane;

    public string[] names;
    public string[] bios_dog;
    public string[] bios_wolf;

    public static SheepManager Instance = null;

    // Use this for initialization
    void Start ()
	{
		for (int i = 0; i < sheepCount; i++)
		{
            GameObject new_sheep = Instantiate(sheepPrefab,
				new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)),
				Quaternion.Euler(0.0f, Random.Range(0, 360), 0.0f));

            GameplayManager.Instance.Sheeps.Add(new_sheep);

            // give id to sheep
            new_sheep.GetComponent<SheepBehaviour>().sheep_id = i;

        }

		GameplayManager.Instance.SheepCount += sheepCount;
	}
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        names = new string[20];
        bios_dog = new string[20];
        bios_wolf = new string[20];
        
        names[0] = "Amish - Benjamin";
        bios_dog[0] = "Oh no! You killed Benjamin! Benjamin was a family man.He had 8 wives and 47 children.He followed simple rules in his life. He grazed, he slept, he loved his family, he paid taxes, he gave money to the church.A boring fellow.";
        bios_wolf[0] = "Benjamin was a family man. He had 8 wives and 47 children. He followed simple rules in his life. He grazed, he slept, he loved his family, he paid taxes, he gave money to the church. A boring fellow.";

        names[1] = "Fanatyk wędkarstwa - Jerry";
        bios_dog[1] = "Oh no! You killed Jerry! Jerry was a fishing fanatic. Half of his apartment was filled with fishing rods the worst. About once a month somebody steps into a hook or an anchor that&#39;s lying on the floor and it needs to be removed at the hospital because that shit is spiky at the edges.";
        bios_wolf[1] = "Jerry was a fishing fanatic. Half of his apartment was filled with fishing rods the worst. About once a month somebody steps into a hook or an anchor that&#39;s lying on the floor and it needs to be removed at the hospital because that shit is spiky at the edges.";

        names[2] = "Członek gangu motocyklowego – Butch";
        bios_dog[2] = "Oh no! You killed Butch! Butch was the leader of the greaser gang known as Tunnel Sheep.Tunnel Sheep rule.They are the Tunnel Sheep.That’s them. And they rule.";
        bios_wolf[2] = "Butch was the leader of the greaser gang known as Tunnel Sheep. Tunnel Sheep rule. They are the Tunnel Sheep. That’s them. And they rule.";

        names[3] = "Gandalf - Cecil";
        bios_dog[3] = "Oh no! You killed Cecil! Cecil, often called Gandalf by his friends, was known in the Skye island’s sheep community as an avid reenactor of the Battle of Helm &#39;s Deep. His wizard beard was 100% natural wool, but he couldn’t cast real spells.He was also a great fan of Epic Sax Guy.";
        bios_wolf[3] = "Cecil, often called Gandalf by his friends, was known in the Skye island’s sheep community as an avid reenactor of the Battle of Helm&#39;s Deep. His wizard beard was 100% natural wool, but he couldn’t cast real spells.He was also a great fan of Epic Sax Guy.";

        names[4] = "Super owca – Alice";
        bios_dog[4] = "Oh no! You killed Alice! Alice’s powers first came into light back in 1997.This is when she donned a red cape as Super Sheep and began the undying fight for goodness and justice.With flying straight into the mouth of danger and exploding together with the villains as her modus operandi, everyone thought that Alice will meet her end in a blazing fire.Who would have thought that a friend will kill her.";
        bios_wolf[4] = "Alice’s powers first came into light back in 1997. This is when she donned a red cape as Super Sheep and began the undying fight for goodness and justice.With flying straight into the mouth of danger and exploding together with the villains as her modus operandi, everyone thought that Alice will meet her end in a blazing fire.Who would have thought that a wolf would devour her whole.";

        names[5] = "Owca Domino Jachaś – Dominic";
        bios_dog[5] = "Oh no! You killed Dominic! Dominic was a people’s man. He always wanted to be a politician.His prime minister election campaign has already started. His main promise was to give every citizen a free medium Hawaiian pizza.";
        bios_wolf[5] = "Dominic was a people’s man. He always wanted to be a politician. His prime minister election campaign has already started. His main promise was to give every citizen a free medium Hawaiian pizza.";

        names[6] = "Zed";
        bios_dog[6] = "Oh no! You killed Zed! This is Zed.Zed’s dead.";
        bios_wolf[6] = "This is Zed. Zed’s dead.";

        names[7] = "Rockstar (KISS) - Starsheep";
        bios_dog[7] = "Oh no! You killed Starsheep! As the founder and the frontsheep of the immensely popular glam metal band, Starsheep was idolized by some and detested by others.His songs Black Sheep, Graze All Nite and Detroit Sheep City are now all - time classics sung by thousands of sheep worldwide.";
        bios_wolf[7] = "As the founder and the frontsheep of the immensely popular glam metal band, Starsheep was idolized by some and detested by others.His songs Black Sheep, Graze All Nite and Detroit Sheep City are now all - time classics sung by thousands of sheep worldwide.";

        names[8] = "Komunista – Vladimir";
        bios_dog[8] = "Oh no! You killed Vladimir! Vladimir was a model citizen, a working sheep who believed strongly in the ideas of common ownership and egalitarianism.He believed that the sheep should seize the means of production.His death from the fangs of the dogs he trusted was as bad as perestroika.";
        bios_wolf[8] = "Vladimir was a model citizen, a working sheep who believed strongly in the ideas of common ownership and egalitarianism.He believed that the sheep should seize the means of production.His death from the fangs of the wolf was still better than perestroika.";

        names[9] = "Hipster – Daisy";
        bios_dog[9] = "Oh no! You killed Daisy! Daisy was a special snowflake.She only wore 100 % natural clothes and recycled, hand - made bags and grazed on vegan and gluten - free grass.She used an iSheep smartphone and only bought coffee (soy milk, double espresso) at Sheepbucks. She couldn’t grow a beard, so instead she made sure not to shave her armpits as a sign of her protest against male dominance.";
        bios_wolf[9] = "Daisy was a special snowflake. She only wore 100% natural clothes and recycled, hand-made bags and grazed on vegan and gluten-free grass.She used an iSheep smartphone and only bought coffee (soy milk, double espresso) at Sheepbucks. She couldn’t grow a beard, so instead she made sure not to shave her armpits as a sign of her protest against male dominance.";

        names[10] = "Trump – Donald";
        bios_dog[10] = "Oh no! You killed Donald! Donald was never very liked among the community, but he had money which allowed him access to the world of politics. He proposed to build a fence to separate the sheep from the wolves (and to make the wolves pay for it), to make the grazing land great again.His wife is grateful for the inheritance money.";
        bios_wolf[10] = "Donald was never very liked among the community, but he had money which allowed him access to the world of politics. He proposed to build a fence to separate the sheep from the wolves (and to make the wolves pay for it), to make the grazing land great again.His wife is grateful for the inheritance money.";

        names[11] = "Weeaboo – Kirito";
        bios_dog[11] = "Oh no! You killed Kirito! His real name was Josh, but he decided that he wanted other sheep to call him Kirito after watching a popular anime series. It was a great series.The best series.Anime is great.Anyone who thinks anime is shit, deserves to die.";
        bios_wolf[11] = "His real name was Josh, but he decided that he wanted other sheep to call him Kirito after watching a popular anime series.It was a great series.The best series.Anime is great.Anyone who thinks anime is shit, deserves to die.";

        names[12] = "Luchador – La Oveja";
        bios_dog[12] = "Oh no! You killed La Oveja! La Oveja, the Luchador sheep was a precious friend to everyone in the community. She always had time to spare to help a sheep in need.But above all, La Oveja was a great sportssheep, unmatched in the ring. She’d like to be remembered for what she did when she was alive, not for the way she died.";
        bios_wolf[12] = "La Oveja, the Luchador sheep was a precious friend to everyone in the community. She always had time to spare to help a sheep in need.But above all, La Oveja was a great sportssheep, unmatched in the ring. She’d like to be remembered for what she did when she was alive, not for the way she died.";

        names[13] = "Gangsta raper – S.H.E.E.P.";
        bios_dog[13] = "S.H.E.E.P. died last night, killed by a friend, fuck, By a trusted shepherd, stabbed in the back. He was the best rapper, homeboy and player , Nobody expected the dog’s betrayal. He died and he’s gone, but let’s not be petty, In heaven he’s now eating his mom’s spaghetti.";
        bios_wolf[13] = "S.H.E.E.P. died last night, killed by a wolf, fuck, He got him good, he became a snack. He was the best rapper, a homie real good, Nobody expected he would become food. He died and he’s gone, but let’s not be petty, In heaven he’s now eating his mom’s spaghetti.";

        names[14] = "Emo owca – Martin";
        bios_dog[14] = "Oh no! You killed Martin! Martin suffered from depression.Other sheep told him that he should just smile and embrace the goodness in life, that depression is not a real thing and he would feel better if he only stopped being sad.They did not understand. Now Martin is dead.";
        bios_wolf[14] = "Martin suffered from depression. Other sheep told him that he should just smile and embrace the goodness in life, that depression is not a real thing and he would feel better if he only stopped being sad.They did not understand. Now Martin is dead.";

        names[15] = "Owca z fedorą – Brian";
        bios_dog[15] = "Oh no! You killed Brian! Brian was a nice guy.He could never get a girlfriend though – because girls prefer assholes over good, loving, caring and supportive sheep.Girls always wanted to be just friends.Nice guys finish last.";
        bios_wolf[15] = "Brian was a nice guy. He could never get a girlfriend though – because girls prefer assholes over good, loving, caring and supportive sheep. Girls always wanted to be just friends.Nice guys finish last.";

        names[16] = "Korpoludek – Finn";
        bios_dog[16] = "Oh no! You killed Finn! Finn spent his life at work. He was a prominent project manager in an advertising agency.Every day he tackled briefs, deadlines, targets, KPIs and, eventually, fuck-ups.He was the perfect employee. His wife and kids left him after his first heart attack.He struggled with alcoholism ever since.";
        bios_wolf[16] = "Finn spent his life at work. He was a prominent project manager in an advertising agency. Every day he tackled briefs, deadlines, targets, KPIs and, eventually, fuck-ups.He was the perfect employee. His wife and kids left him after his first heart attack.He struggled with alcoholism ever since.";

        names[17] = "Student prawa - Johnny";
        bios_dog[17] = "Oh no! You killed Johnny! Johnny studied law at Cambridge.He was not a nice person. He was vain and stuck - up.He felt entitled.He felt that the world revolved around him. He looked down at other sheep. We won’t miss him.";
        bios_wolf[17] = "Johnny studied law at Cambridge. He was not a nice person. He was vain and stuck-up. He felt entitled.He felt that the world revolved around him. He looked down at other sheep. We won’t miss him.";

        names[18] = "Gamer - Kevin";
        bios_dog[18] = "Oh no! You killed Kevin! Kevin, a.k.a.Haxor666, spent his days playing Herdborne and Lamb Souls. He was the ultimate gamer, until he was defeated by an eight - year - old in a PvP match.After that he switched to Sheeptendo.";
        bios_wolf[18] = "Kevin, a.k.a. Haxor666, spent his days playing Herdborne and Lamb Souls. He was the ultimate gamer, until he was defeated by an eight - year - old in a PvP match.After that he switched to Sheeptendo.";

        names[19] = "Artystka – Lucy";
        bios_dog[19] = "Oh no! You killed Lucy! Lucy was always the life of the party. She had the soul of an artist.She could paint, sculpt and perform.Her most remembered performance involved self-shearing in public, it was meant to bring attention to the repetitive cycle of a sheep’s life.";
        bios_wolf[19] = "Lucy was always the life of the party. She had the soul of an artist. She could paint, sculpt and perform.Her most remembered performance involved self-shearing in public, it was meant to bring attention to the repetitive cycle of a sheep’s life.";

    }

}
