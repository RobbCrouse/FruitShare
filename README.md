# FruitShare
<table>
<tr>
<td>
    An easy way to share your fruit!  FruitShare was designed to bring communities together, those with fruit, and those who enjoy it.  Homeowners are often stuck with more fruit than they can handle or fruit they just don't like.  This fruit, left unharvested, eventually makes a mess, and a lot of waste.  Meanwhile, neighbors are driving by everyday on their way to buy "local", organic produce from strangers.  FruitShare aims to bring these neighbors together in a mutually beneficial way.
    </td>
    </tr>
    </table>
    
    
## Site

### Landing Page
Basic Home page with information about the site and its benefits.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareIndex.png">
</p>

### Login or Register Page
New Users are able to Register, while existing Users are able to Login.  All fields have specific validations and custom error messages.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareRegister.png">
</p>

### Dashboard
Users are personally welcomed and presented with a list of available fruit.  Users are shown conditional options for each fruit:  
      - If the fruit was added by another user, you have the option to claim it, which puts your email on the fruit owner's Detail list,
          or change your mind, which removes a previously claimed fruit from your list and your email from the owner's Detail list.  
      - If the fruit was added by the user, they have the option to Delete it, Edit it, or view its Details.
    
<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareDash.png">
</p>

### Add Page
Users are able to Add a fruit to the Dashboard.  All fields have specific validations and custom error messages.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareAdd.png">
</p>

### Edit Page
Users are presented with an editable page with their fruit's current information.  All fields have specific validations and custom error messages.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareEdit.png">
</p>

### Sharing Page
Users are presented with a list of all of the fruit they're sharing, with options to Edit, Delete, or go to the Details page.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareShared.png">
</p>

### Claiming Page
Users are presented with a list of all of the fruit they're claiming, and the ability to opt out of each fruit if they've changed their mind.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareClaimed.png">
</p>

### Details Page
Users who are sharing fruit are presented with a list of all the user names and emails of members that are interested in claiming that particular fruit.

<p align="center">
    <img src="https://github.com/RobbCrouse/FruitShare/blob/master/FruitScreens/FruitShareDetails.png">
</p>

### Mobile support
FruitShare is compatible with devices of all sizes, and improvements are being made.

### Development
Want to help?  Let's party up and improve it together!

To fix a bug or enhance an existing module, follow these steps:

    - Fork the repo
    - Create a new branch (`git checkout -b improve-feature`)
    - Make the appropriate changes in the files
    - Add changes to reflect the changes made
    - Commit your changes (`git commit -am 'Improve feature'`)
    - Push to the branch (`git push origin improve-feature`)
    - Create a Pull Request
    
### Bug/ Feature Request

If you find a bug (the website couldn't handle the query and/ or gave undesired results), please open an issue [here]
(https://github.com/RobbCrouse/FruitShare/issues/new) by including your search query and the expected result.

If you'd like to request a new function, feel free to do so by opening an issue [here]
(https://github.com/RobbCrouse/FruitShare/issues/new) and include sample queries and corresponding results.

### Built With

- [Bootstrap](http://getbootstrap.com/) - Extensive list of components and bundled Javascript plugins.

### To-do

- Add some sorting features to the Dashboard.
- Show only fruit being shared within a specific radius, maybe a radius chosen by the fruit claimer.
