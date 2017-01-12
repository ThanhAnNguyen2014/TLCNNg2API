import { Component, ChangeDetectorRef,OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
import { Location } from '@angular/common';
import { CartService } from '../service/cart.service';
import { CartFull, Cart } from '../module/cart';

//import { cart } from '../module/cart';
declare var $: any;
@Component({
    selector: 'cart',
    template: require('./cart.component.html'),
    styles: [require('./cart.component.css')]
})

export class CartComponent implements OnInit {

    public cart1="0,000 VNĐ";
    public line: Cart;
    public rowDataMainForm = [];
    id: number;
   // line: cart;
    constructor(private changeDetectorRef: ChangeDetectorRef, private auth: Auth, private location: Location, private cartService: CartService) {
        // get cart

            console.log(this.cart1);
            this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
                error => alert(error),
                () => console.log("getCart");
            this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
            
    };


    ngOnInit() {

            this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
                error => alert(error),
                () => console.log("getCart");
            this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
    }

    goBack(): void {
        this.location.back();
    }

    deleteLineCart(rowNumber: number,id) {
        this.rowDataMainForm.splice(rowNumber, 1);
        
        //xóa line cart
        this.cartService
            .removeLineCart(id);
        this.changeDetectorRef.detectChanges();
        //load lia card

        this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
            error => alert(error),
            () => console.log("getCart");
        console.log(this.rowDataMainForm);
        this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
        
        
        
    }


    PlusProduct(rowNumber: number, id) {
        this.rowDataMainForm.splice(rowNumber, 0);
      

        //add cart
        this.cartService
            .addToCart(id);
       
        //load lia card
       
        this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
        error => alert(error),
            () => console.log("getCart");
        console.log(this.rowDataMainForm);
        this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
        this.changeDetectorRef.detectChanges();
        
    }

    MinusProduct(rowNumber: number, id) {
        this.rowDataMainForm.splice(rowNumber, 0);
        

        //giam product cart
        this.cartService
            .removeToCart(id);

        //load lia card
       
        this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
            error => alert(error),
            () => console.log("getCart");
        console.log(this.rowDataMainForm);
        this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
        this.changeDetectorRef.detectChanges();
    }
    
};