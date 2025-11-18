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