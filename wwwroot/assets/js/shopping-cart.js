const localName = "braga-favs";
const localNameCart = "braga-cart";

// favorites
function addProductToFav(id) {
  let products = [];
  if (localStorage.getItem(localName)) {
    products = JSON.parse(localStorage.getItem(localName)) || [];
  }
  products.push(id);
  localStorage.setItem(localName, JSON.stringify(products));
  favCheck();
}

function removeProductFromFav(id) {
  // store products in local storage
  let storageProducts = JSON.parse(localStorage.getItem(localName));
  let products = storageProducts.filter((productID) => productID !== id);
  localStorage.setItem(localName, JSON.stringify(products));
  favCheck();
}

function isInFav(id) {
  let storageProducts = JSON.parse(localStorage.getItem(localName)) || [];
  return storageProducts.find((productID) => productID !== id);
}

function favCheck() {
  const storageProducts = JSON.parse(localStorage.getItem(localName)) || [];
  const productCards = document.querySelectorAll(".product-card");
  
  if (productCards) {
    productCards.forEach((element) => {
      if (
        storageProducts &&
        element.querySelector("#added-to-fav") &&
        storageProducts.find(p => p === element.getAttribute("id"))
      ) {
        element.querySelector("#added-to-fav").style.display = "inline-block";
        element.querySelector("#add-to-fav").style.display = "none";
        if (element.querySelector(".quantity-content")) {
          element.querySelector(".quantity-content").style.display = "none";
        }
      } else {
        if (
          element.querySelector("#added-to-fav") &&
          element.querySelector("#add-to-fav")
        ) {
          element.querySelector("#added-to-fav").style.display = "none";
          element.querySelector("#add-to-fav").style.display = "inline-block";
        }
      }
    });
  }
}

function favNumbersCheck(){
  let storageProducts = JSON.parse(localStorage.getItem(localName)) || [];
  document.querySelector('#fav-counter').textContent = storageProducts?.length || null;
}

function getAllProductsFromFav() {
  return JSON.parse(localStorage.getItem(localName)) || [];
}




// cart
function addProductToCart(
  product = { id, color, size, quantity: 1 }
) {
  let products = [];
  if (localStorage.getItem(localNameCart)) {
    products = JSON.parse(localStorage.getItem(localNameCart));
  }
  if(!isInCart(product.id, product.color, product.size)){
      products.push(product);
      localStorage.setItem(localNameCart, JSON.stringify(products));
      Swal.fire({
        title: `${product.title} has been added to cart`,
        icon: "success",
        confirmButtonText: "Ok",
      });
      cartNumbersCheck();
  }else{
    Swal.fire({
        title: `You already have this product in cart`,
        icon: "warning",
        confirmButtonText: "Close",
      });
  }
}

function removeProductFromCart(productId) {
  // store products in local storage
  let storageProducts = JSON.parse(localStorage.getItem(localNameCart));
  let products = storageProducts.filter((product) => product?.id !== productId);
  localStorage.setItem(localNameCart, JSON.stringify(products));
  cartNumbersCheck();}

function isInCart(id, color, size ) {
  let storageProducts = JSON.parse(localStorage.getItem(localNameCart)) || [];
  return storageProducts.find((product) => (product?.id === id && product?.color === color && product?.size === size));
}



function updateQuantity(productId, quantity, size, color) {
  let products = [];
  if (localStorage.getItem(localNameCart)) {
    products = JSON.parse(localStorage.getItem(localNameCart)) || [];
  }
  products = products.map((e) => {
    if (e.id === productId && e.size === size && e.color === color) {
      e.quantity = quantity;
      return e;
    }
    return e;
  });
  localStorage.setItem(localNameCart, JSON.stringify(products));
  cartNumbersCheck();
}

function getAllProductsFromCart() {
  return JSON.parse(localStorage.getItem(localNameCart)) || [];
}


function cartNumbersCheck(){
    let storageProducts = JSON.parse(localStorage.getItem(localNameCart)) || [];
    document.querySelector('#cart-counter').textContent = storageProducts?.length || null;
}

function removeAllFromCart(){
  localStorage.setItem(localNameCart, JSON.stringify([]));
  cartNumbersCheck();

}

window.onload = () => {
 try{
  favCheck();
  cartNumbersCheck();
  favNumbersCheck();
 }catch(err){
  console.error(err);
 }
};
