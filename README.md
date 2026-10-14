[Français](README.md) | [English](README.en.md)

# Village

*RIP : Repose en Paix*

Un projet de jeu Unity : un aventurier mort revient à la vie sous forme de squelette dans le donjon où il a péri, des années après sa mort. Poussé par l'envie de retrouver les siens, il s'en échappe et rejoint son ancien village, aujourd'hui en grande partie devenu un cimetière, pour découvrir ce qu'il est advenu de sa famille et lui rendre hommage.

Le jeu complet se joue en deux temps : une traversée 2D façon Metroidvania/Souls-like dans le donjon, puis une exploration 3D en low-poly dans le village et le cimetière, avec dialogues, quêtes annexes et énigmes. Ce dépôt réunit les scripts C# des deux parties.

> **Remarque sur ce dépôt :** ceci est une version allégée du projet Unity complet. Il ne contient que les scripts C# originaux, sans les scènes, les assets graphiques/animation/audio sous licence ni les fichiers de configuration du projet. Le projet ne s'ouvre donc pas tel quel dans Unity ; ce dépôt sert à montrer le code, pas à fournir un build jouable.

## Technologies

- Unity 6000.0.36f1 (Unity 6)
- Universal Render Pipeline (URP)
- Cinemachine, Unity Input System, AI Navigation (NavMesh), Timeline, Visual Scripting
- TextMeshPro pour les dialogues et l'UI

## Systèmes de gameplay

- **Déplacement et caméra** : contrôleur de personnage à la troisième personne (`CharacterController`) avec saut, gravité et rotation vers la direction de marche ; bascule entre caméras cinématiques Cinemachine et vue à la première personne avec la touche Tab, visée à la souris en FPS avec des limites d'angle réglables.
- **Interaction** : détection des objets à portée par sphère de collision, déclenchée avec la touche E ; bulles de dialogue qui s'orientent vers la caméra et se détruisent après quelques secondes ; affichage contextuel de l'action disponible (parler, ouvrir une porte, etc.).
- **PNJ et dialogues** : PNJ qui patrouillent entre des points via le NavMesh et s'arrêtent pour parler quand le joueur entre dans leur champ de vision ; texte de dialogue affiché lettre par lettre, qu'on peut accélérer ou faire défiler au clic ; certains PNJ changent de message selon ce que le joueur a dans son inventaire.
- **Inventaire et quêtes** : collecte de clés et de fleurs trouvées dans le monde ; les clés ouvrent des portes qui pivotent autour d'un gond et se consomment à l'usage ; une quête de fleurs ouvre une crypte une fois le bon nombre réuni ou déposé dans la zone prévue ; une fleur peut aussi être offerte à une tombe pour lui rendre hommage.
- **Ennemis et combat** : IA ennemie générique qui patrouille, poursuit et attaque selon la distance et la ligne de vue avec le joueur ; un poulet qui reste inoffensif tant qu'on ne l'embête pas, mais devient agressif et charge le joueur après l'avoir frappé cinq fois ; combat de boss déclenché par zone, avec sa propre UI de vie et une récompense de score à sa mort ; zones de dégâts oscillant verticalement dans la partie 2D.
- **Progression et score** : un score de scène temporaire se cumule au score total une fois la zone validée ; certains passages exigent un score minimum pour continuer, sinon un message prévient le joueur ; les niveaux se débloquent progressivement et la sauvegarde persiste d'une session à l'autre.
- **Menus et identité du joueur** : il faut saisir un nom avant de pouvoir utiliser les boutons du menu principal ; une UI affiche en continu le nom et le score du joueur ; un bouton permet de réinitialiser entièrement la sauvegarde (nom, score, niveaux débloqués).
- **Audio** : un gestionnaire audio unique change la musique selon la zone visitée ; des sons dédiés accompagnent l'ouverture ou le verrouillage des portes et la collecte d'objets.
- **Fin de partie** : atteindre la tombe de la famille déclenche un son particulier et un événement de victoire global ; une variante par zone affiche une UI de victoire et met le jeu en pause.

## Captures d'écran

Version jouable : [ben11178.itch.io/rip](https://ben11178.itch.io/rip)

| ![Écran titre](Screenshots/screenshot-1.png) | ![Piège à pointes](Screenshots/screenshot-4.png) |
|:---:|:---:|
| *Écran titre, avec le choix entre la partie 2D et la partie 3D* | *Un piège à pointes à franchir* |
| ![Traversée du donjon](Screenshots/screenshot-3.png) | ![Combat de boss](Screenshots/screenshot-2.png) |
| *Traversée des plateformes du donjon* | *Combat contre le boss « Slimus Maximus » dans le donjon* |
| ![Marché du village](Screenshots/screenshot-5.png) | |
| *Le marché du village, en 3D* | |
