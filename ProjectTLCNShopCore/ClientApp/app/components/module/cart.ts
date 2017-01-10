export class CartFull {
    cart: Cart;

    totalPrice: string;
}

export class Cart {
    line: Lines[];

}
export class Lines {
    cartId: number;
    quantity: number;
    price: string;
    product: Product[];

}
interface Product {

    productID: number;
    productName: string;
    unitPrice: number;
    discount: number;
    picture: string;
    note: string;
}