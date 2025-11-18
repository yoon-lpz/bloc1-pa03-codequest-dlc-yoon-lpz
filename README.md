# Summary
This is a little game about a wizard training to defeat a dungeon and getting some items, divided by chapters.

## Chapter 1: Train your wizard
The first time you play this, you name the wizard.

During this chapter, the wizard trains so he can earn power.

## Chapter 2: Increase LVL
A random monster appears, with its Health Points (HP).

The wizard throws a dice and it deals damage to the monster.

# Test games

## Menu

*No exceptions: first starts chapter 1, then ends with 0*

| instruction | iteration | instruction | wizardName | title          | wizardXP | outcome                                   |
|-------------|-----------|-------------|------------|----------------|----------|-------------------------------------------|
| 1           | 1         | 1           | -          | -              | -        | Output: Menu title                        |
| 1           | 1         | 2           | -          | -              | -        | !string.IsNullOrEmpty(wizardName)): false |
| 1           | 1         | 3 - 11      | -          | -              | -        | Output: menu options                      |
| 1           | 1         | 12          | -          | -              | -        | Input: 1 (No exception)                   |
| 1           | 1         | 13          | -          | -              | -        | Switch case 1 starts                      |
| 1           | 2         | 1           | Yoon       | Zyn The Bugged | 7        | Output: MenuTitle                         |
| 1           | 2         | 2           | Yoon       | Zyn The Bugged | 7        | !string.IsNullOrEmpty(wizardName)): true  |
| 1           | 2         | 3           | Yoon       | Zyn The Bugged | 7        | Output: MenuWelcome                       |
| 1           | 2         | 4 - 12      | Yoon       | Zyn The Bugged | 7        | Output: menu options                      |
| 1           | 2         | 13          | Yoon       | Zyn The Bugged | 7        | Input: 0 (No exception)                   |
| 1           | 2         | 14          | Yoon       | Zyn The Bugged | 7        | Exits program                             |

*Input is a text, instead of a number*

| instruction | iteration | instruction | wizardName | title | wizardXP | op      | outcome                                       |
|-------------|-----------|-------------|------------|-------|----------|---------|-----------------------------------------------|
| 1           | 1         | 1           | -          | -     | -        | -       | Output: Menu title                            |
| 1           | 1         | 2           | -          | -     | -        | -       | !string.IsNullOrEmpty(wizardName)): false     |
| 1           | 1         | 3 - 11      | -          | -     | -        | -       | Output: menu options                          |
| 1           | 1         | 12          | -          | -     | -        | -       | Input: asdad (Exception)                      |
| 1           | 1         | 13          | -          | -     | -        | op = -1 | Try: op = int.Parse("asdad"), catch exception |
| 1           | 1         | 14          | -          | -     | -        | op = -1 | switch case (op): default                     |
| 1           | 1         | 15          | -          | -     | -        | op = -1 | Output: InputErrorMessage                     |
| 1           | 2         | 1           | -          | -     | -        | op = -1 | Show menu and asks input again (loop until 0) |

*Input is not a valid number*

| instruction | iteration | instruction | wizardName | title | wizardXP | op     | outcome                                       |
|-------------|-----------|-------------|------------|-------|----------|--------|-----------------------------------------------|
| 1           | 1         | 1           | -          | -     | -        | -      | Output: Menu title                            |
| 1           | 1         | 2           | -          | -     | -        | -      | !string.IsNullOrEmpty(wizardName)): false     |
| 1           | 1         | 3 - 11      | -          | -     | -        | -      | Output: menu options                          |
| 1           | 1         | 12          | -          | -     | -        | -      | Input: 8 (Exception)                          |
| 1           | 1         | 13          | -          | -     | -        | op = 8 | Try: op = int.Parse("8"), no exception        |
| 1           | 1         | 14          | -          | -     | -        | op = 8 | switch case (op): default                     |
| 1           | 1         | 15          | -          | -     | -        | op = 8 | Output: InputErrorMessage                     |
| 1           | 2         | 1           | -          | -     | -        | op = 8 | Show menu and asks input again (loop until 0) |

## Chapter 1

*Name is correct: Yoon*
| instruction | iteration | instruction | wizardName | outcome                                                          |
|-------------|-----------|-------------|------------|------------------------------------------------------------------|
| 1           | -         | -           | -          | string.IsNullOrEmpty(wizardName) = true                          |
| 2           | 1         | 1           | -          | Output: AskName                                                  |
| 2           | 1         | 2           | Yoon       | Input: Yoon                                                      |
| 2           | 1         | 3           | Yoon       | string.IsNullOrEmpty(wizardName) = false                         |
| 2           | 1         | 4           | Yoon       | string.IsNullOrEmpty(wizardName) = false                         |
| 3           | -         | -           | Yoon       | wizardName.Trim() --> "Yoon"                                     |
| 4           | -         | -           | yoon       | wizardName.ToLower() --> "yoon"                                  |
| 5           | -         | -           | Yoon       | char.ToUpper(wizardName[0]) + wizardName.Substring(1) --> "Yoon" |
| 6           | 1         | 1           | Yoon       | Executes training days and give a title depending on the result  |

*Name is empty*
| instruction | iteration | instruction | wizardName | outcome                                   |
|-------------|-----------|-------------|------------|-------------------------------------------|
| 1           | -         | -           | -          | string.IsNullOrEmpty(wizardName) --> true |
| 2           | 1         | 1           | -          | Output: AskName                           |
| 2           | 1         | 2           |            | Input:                                    |
| 2           | 1         | 3           |            | string.IsNullOrEmpty(wizardName) --> true |
| 2           | 1         | 4           |            | Output: WrongName                         |
| 2           | 1         | 5           |            | string.IsNullOrEmpty(wizardName) --> true |
| 2           | 2         | 1           |            | Asks name until not empty                 |

*Name is number*
| instruction | iteration | instruction | wizardName | outcome                                    |
|-------------|-----------|-------------|------------|--------------------------------------------|
| 1           | -         | -           | -          | string.IsNullOrEmpty(wizardName) --> true  |
| 2           | 1         | 1           | -          | Output: AskName                            |
| 2           | 1         | 2           | "23"       | Input: 23                                  |
| 2           | 1         | 3           | "23"       | string.IsNullOrEmpty(wizardName) --> false |
| 2           | 1         | 4           | "23"       | string.IsNullOrEmpty(wizardName) --> false |
| 2           | 1         | 5           | "23"       | try wizardName.ToLower() --> Exception     |
| 2           | 1         | 6           | "23"       | Output: WrongName                          |
| 2           | 1         | 7           | ""         | wizardName = ""                            |
| 2           | 2         | 1           | ""         | Repeat loop until correct name             |

## Chapter 2
*There are no inputs, everything works ok*
| instruction | iteration | instruction | monster | actHP | actMonster   | diceResult | wizardLevel | outcome                                             |
|-------------|-----------|-------------|---------|-------|--------------|------------|-------------|-----------------------------------------------------|
| 1           | -         | -           | 3       | -     | -            | -          | 1           | monster = rnd.Next(0, monsterNames.Length) --> 3    |
| 2           | -         | -           | 3       | 11    | -            | -          | 1           | actHP = monsterHP[monster] --> 11                   |
| 3           | -         | -           | 3       | 11    | "Ember Wolf" | -          | 1           | actMonster = monsterNames[monster] --> "Ember Wolf" |
| 4           | -         | -           | 3       | 11    | "Ember Wolf" | -          | 1           | Output: Monster appears                             |
| 5           | -         | -           | 3       | 11    | "Ember Wolf" | -          | 1           | Output: MonsterHPMessage                            |
| 6           | 1         | 1           | 3       | 11    | "Ember Wolf" | 6          | 1           | diceResult = rnd.Next(1,7) --> 6                    |
| 6           | 1         | 2           | 3       | 11    | "Ember Wolf" | 6          | 1           | Output: DiceRollMessage                             |
| 6           | 1         | 3           | 3       | 11    | "Ember Wolf" | 6          | 1           | Output: dice[5]                                     |
| 6           | 1         | 3           | 3       | 5     | "Ember Wolf" | 6          | 1           | actHP - diceResult < 0 --> false (actHP = 5)        |
| 6           | 1         | 4           | 3       | 5     | "Ember Wolf" | 6          | 1           | Output: MonsterTakeDamage                           |
| 6           | 1         | 5           | 3       | 5     | "Ember Wolf" | 6          | 1           | Output: MonsterHPMessage                            |
| 6           | 1         | 6           | 3       | 5     | "Ember Wolf" | 6          | 1           | actHP > 0 --> true                                  |
| 6           | 1         | 7           | 3       | 5     | "Ember Wolf" | 6          | 1           | Output: RollAgain                                   |
| 6           | 1         | 8           | 3       | 5     | "Ember Wolf" | 6          | 1           | ReadLine (just to continue)                         |
| 6           | 1         | 9           | 3       | 5     | "Ember Wolf" | 6          | 1           | actHP > 0 --> true                                  |
| 6           | 2         | 1           | 3       | 5     | "Ember Wolf" | 5          | 1           | diceResult = rnd.Next(1,7) --> 5                    |
| 6           | 2         | 2 - 3       | 3       | 5     | "Ember Wolf" | 5          | 1           | Outputs: DiceRollMessage, dice[4]                   |
| 6           | 2         | 4           | 3       | 0     | "Ember Wolf" | 5          | 1           | actHP - diceResult  < 0 --> false (actHP = 0)       |
| 6           | 2         | 5 - 6       | 3       | 0     | "Ember Wolf" | 5          | 1           | Outputs: MonsterTakeDamage, MonsterHPMessage        |
| 6           | 2         | 7           | 3       | 0     | "Ember Wolf" | 5          | 1           | actHP > 0 --> false                                 |
| 6           | 2         | 8           | 3       | 0     | "Ember Wolf" | 5          | 1           | actHP > 0 --> false                                 |
| 7           | -         | -           | 3       | 0     | "Ember Wolf" | 5          | 1           | Output: MonsterDefeated                             |
| 8           | -         | -           | 3       | 0     | "Ember Wolf" | 5          | 1           | wizardLevel < 5 --> true                            |
| 9 - 10      | -         | -           | 3       | 0     | "Ember Wolf" | 5          | 2           | wizardLevel++ --> 2, Output: LevelUp                |