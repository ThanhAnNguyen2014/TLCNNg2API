import { Component, ChangeDetectorRef } from '@angular/core';
import { Auth } from '../service/auth.service';
import { Location } from '@angular/common';
import { CartService } from '../service/cart.service';
import { CartFull, Cart} from '../module/cart';
//import { cart } from '../module/cart';
declare var $: any;
@Component({
    selector: 'cart',
    template: require('./cart.component.html'),
    styles: [require('./cart.component.css')]
})

export class CartComponent {

    public cart1: string;
    public line: Cart;
    public rowDataMainForm = [];
    id: number;
   // line: cart;
    constructor(private changeDetectorRef: ChangeDetectorRef,private auth: Auth, private location: Location, private cartService: CartService) {
        // get cart

            console.log(this.cart1);
            this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
                error => alert(error),
                () => console.log("getCart");
            this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
            
    };
    //ngOnInit():any {
        //// quantity plus
        //$('.value-plus').on('click', function () {
        //    var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) + 1;
        //    if (newVal <= 10) divUpd.text(newVal);
        //});
        //// quantity minus
        //$('.value-minus').on('click', function () {
        //    var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) - 1;
        //    if (newVal >= 1) divUpd.text(newVal);
        //});

        //// deleted item in cart
        //$('.close1').on('click', function (c) {
        //    $('.rem1').fadeOut('slow', function (c) {
        //        $('.rem1').remove();
        //    });
        //});
    	
     
        // get cart
       

        //}
    //plusCart(id) {
    //        this.cartService
    //        .addToCart(id);

    //}
    //removeCart(id) {
    //    this.cartService
    //        .removeToCart(id);
    //}

    //removeLineCart(id) {
    //    this.cartService
    //        .removeLineCart(id);
    //}


    goBack(): void {
        this.location.back();
    }
    //
    //ngAfterViewInit() {



    //}

    //rowDataMainForm1 = [{
    //    cartId: 0,
    //    quantity: 1,
    //    price: "490,440 VNĐ",
       
    //}];
    deleteLineCart(rowNumber: number,id) {
        this.rowDataMainForm.splice(rowNumber, 1);
   
        //xóa line cart
        this.cartService
            .removeLineCart(id);

        //load lia card

        this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
            error => alert(error),
            () => console.log("getCart");
        console.log(this.rowDataMainForm);
        this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
        
        this.changeDetectorRef.detectChanges();
        
        
    }


    PlusProduct(rowNumber: number, id) {
        this.rowDataMainForm.splice(rowNumber, 0);
      

        //add cart
        this.cartService
            .addToCart(id);

        //load lia card
       
    
        this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
        this.cartService.getCart().subscribe(data1 => this.cart1 = data1);
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