# Gold Badge Console Application Challenges

Three console applications created for Eleven Fifty Academy Gold Badge final project.

## Komodo Cafe

### POCO: MenuItem
#### Properties
1. Number 
   * int
   * represents the menu number of the item
2. Name
   * string
   * Name of the menu item i.e. "mac and cheese"
3. Description 
   * string
   * Description of the food item
4. IngredientList
   * List<string> 
   * List of ingredients
5. Price
   * decimal
   * Price of the item
   
#### Constructors
1. MenuItem()
   * Number set to zero;
   * Name set to empty string
   * Description set to empty string
   * IngredientList initialized
   * Price set to zero
2. MenuItem(int num, string name, string description, List<string>ingredients, decimal price)
   * Sets properties to corresponding arguments
3. MenuItem(MenuItem)
   * Copy Constructor

#### Methods/Overloads
1.  Equality Operator
    *  returns true if properties equal each other
    *  SequenceEqual used for determing list equality
2. Inequality Operator
    *  returns the opposite of the equality operator
3.  Equals(Object)
    *  Utilizes equality operator overload to determine equality
4. GetHashCode
    * defines hash code based on menu properties

### REPO: MenuItemRepo 
#### Properties/Fields
1. _menu
   * field
   * container for menu items
   * List<MenuItem>
#### Methods
1. AddMenuItem
   * MenuItem -> bool
   * Adds new menu item to repo.
   * Returns true if successful
2. GetMenuList
   *  void -> List<MenuItem>
   *  Returns field _menu;
3. RemoveMenuItem
   * MenuItem -> bool
   * removes menu item from repo
   * returns true if successful
4. IsInMenu
   * MenuItem -> bool
   * string -> bool
   * int -> bool
   * returns true if menuitem, menuitem name or menuitem number in repo
5. GetFoodByName
   * string -> MenuItem
   * returns menu item if name in repo, else returns null
6.  GetFoodByName
   * num -> MenuItem
   * returns menu item if number in repo, else returns null
## Komodo Claims Department
### POCO: Claims
#### Properties
1. NextClaim
   * static int
   * defaults to 1;
   * every time a Claims object is initializedm next claim increases by one
2. ClaimNumber
   * int
   * Claim number of the claim, unique for each object
3. ClaimType
   * TypeOfClaim (enum)
   * represents if claim is car, theft or home
4. Description
   * string
   * description of the claim
5. ClaimAmount
   * decimal
   * amount of money being claimed 
6. DateOfIncident
   * DateTime
   * Date incident occured
7. DateOfClaim
   * DateTime
   * Date of claim
8. IsValid
   * bool
   * calculated on construction of object, determines if claim is valid based on the date of the accident and the date of the claim.
#### Constructors
1. Claims()
   * ClaimNumber equals NextClaim
   * Date of Incident and Date of Claim set to current time
   * IsValid calculated
2. Claims (TypeOfClaim, string description, decimal claimAmount, DateTime date of incident, DateTime dateOfClaim )
   *  ClaimNumber equals NextClaim
   *  Sets properties to corresponding arguments
   *  IsValid calculated
### REPO: ClaimsRepo
#### Field
1. _claimsQueue
   * Queue<claims> 
   * queue for which claim needs to be addressed next
#### Constructors
1. Empty Constructor
   * intiates new queue
#### Methods
1. AddClaim
   * Claims -> bool
   * Enqueues new claim
   * returns true if claim not already in queue
2. GetClaimsQueue
   * void ->  Queue <Claims>
   * returns the field
3. RemoveClaim
   * void-> void
   * Dequeues queue
## Komodo Insurance : Badges
### POCO: Badge
#### Properties
1. BadgeID
   * int
   * ID for badge
2. RoomList
   * List<string>
   * list of rooms badge has access to
#### Constructors
1. Empty Constructor
   * initialized new list
2. Badge(int IdNum, List<string> roomList )
   * sets properties equal to corresponding arguments
### REPO: BadgeRepo
#### Fields
1. _badgeDictionary
   * Dictionary<int, Badge>
   * dictionary for badges, keys are badge ID
#### Constructors
1. Empty Constructor
   1. initializes new dictionary
#### Methods
1. AddBadge
   * Badge -> bool
   * adds new badge to dictionary
   * returns true if badge is not in repo
2. GetBadgeDictionary
   * void -> Dictionary<int, Badge>
   * returns repo
3. UpdateBadge
   * Badge -> bool
   * Updates list of rooms badge has access to
   * returns true if badge in repo
4. DeleteBadge
   * Badge -> bool
   * Deletes badge from dictionary
   * returns true if badge deleted