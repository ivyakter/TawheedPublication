<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Pages_Cart_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="content">
		<div class="content-page woocommerce">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<h2 class="title-shop-page">checkout</h2>
						<div class="row">
							<div class="col-md-6 col-sm-6 col-ms-12">
								<div class="check-billing">
									<div class="form-my-account">
										<h2 class="title18">Billing Details</h2>
										<p class="clearfix box-col2">
											<input type="text" value="First Name *" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" />
											<input type="text" value="last name *" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" />
										</p>
										<p><input type="text" value="Company Name" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" /></p>
										<p class="clearfix box-col2">
											<input type="text" value="Email *" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" />
											<input type="text" value="phone *" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" />
										</p>
										<p>
											<select name="country" id="country">
												<option value="">Country*</option>
												<option value="">United State</option>
												<option value="">England</option>
												<option value="">Germany</option>
												<option value="">France</option>
											</select>
										</p>
										<p><input type="text" value="Address *" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" /></p>
										<p class="clearfix box-col2">
											<input type="text" value="Postcode / Zip" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" />
											<input type="text" value="Town / City *" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''" />
										</p>
										<p>
											<input type="checkbox"  id="remember" /> <label for="remember">Create an account?</label>
										</p>
									</div>
								</div>
							</div>
							<div class="col-md-6 col-sm-6 col-ms-12">
								<div class="check-address">
									<div class="form-my-account">
										<p class="ship-address">
											<input type="checkbox"  id="address" /> <label for="address">Ship to a different address?</label>
										</p>
										<p>
											<textarea cols="30" rows="10" onblur="if (this.value=='') this.value = this.defaultValue" onfocus="if (this.value==this.defaultValue) this.value = ''">Order Notes</textarea>
										</p>
									</div>
								</div>		
							</div>
						</div>
						<h3 class="order_review_heading">Your order</h3>
						<div class="woocommerce-checkout-review-order" id="order_review">
							<div class="table-responsive">
								<table class="shop_table woocommerce-checkout-review-order-table">
									<thead>
										<tr>
											<th class="product-name">Product</th>
											<th class="product-total">Total</th>
										</tr>
									</thead>
									<tbody>
										<tr class="cart_item">
											<td class="product-name">
												Luphen Caunoiteng kug&nbsp; <span class="product-quantity">× 1</span>
											</td>
											<td class="product-total">
												<span class="amount">$68.00</span>						
											</td>
										</tr>
										<tr class="cart_item">
											<td class="product-name">
												Cooc Huyinh Phale&nbsp;	<span class="product-quantity">× 2</span>
											</td>
											<td class="product-total">
												<span class="amount">$38.00</span>
											</td>
										</tr>
									</tbody>
									<tfoot>
										<tr class="cart-subtotal">
											<th>Subtotal</th>
											<td><strong class="amount">$106.00</strong></td>
										</tr>
										<tr class="shipping">
											<th>Shipping</th>
											<td>
												<ul id="shipping_method" class="list-none">
													<li>
														<input type="radio" class="shipping_method" checked="checked" value="free_shipping" id="shipping_method_0_free_shipping" data-index="0" name="shipping_method[0]">
														<label for="shipping_method_0_free_shipping">Free Shipping</label>
													</li>
													<li>
														<input type="radio" class="shipping_method" value="local_delivery" id="shipping_method_0_local_delivery" data-index="0" name="shipping_method[0]">
														<label for="shipping_method_0_local_delivery">Local Delivery (Free)</label>
													</li>
													<li>
														<input type="radio" class="shipping_method" value="local_pickup" id="shipping_method_0_local_pickup" data-index="0" name="shipping_method[0]">
														<label for="shipping_method_0_local_pickup">Local Pickup (Free)</label>
													</li>
												</ul>
											</td>
										</tr>
										<tr class="order-total">
											<th>Total</th>
											<td><strong><span class="amount">$106.00</span></strong> </td>
										</tr>
									</tfoot>
								</table>
							</div>
							<div class="woocommerce-checkout-payment" id="payment">
								<ul class="payment_methods methods list-none">
									<li class="payment_method_bacs">
										<input type="radio" data-order_button_text="" value="bacs" name="payment_method" class="input-radio" id="payment_method_bacs" checked="checked">
										<label for="payment_method_bacs">Direct Bank Transfer 	</label>
										<div style="" class="payment_box payment_method_bacs">
											<p>Make your payment directly into our bank account. Please use your Order ID as the payment reference. Your order won’t be shipped until the funds have cleared in our account.</p>
										</div>
									</li>
									<li class="payment_method_cheque">
										<input type="radio" data-order_button_text="" value="cheque" name="payment_method" class="input-radio" id="payment_method_cheque">
										<label for="payment_method_cheque">Cheque Payment 	</label>
											<div style="display:none;" class="payment_box payment_method_cheque">
											<p>Please send your cheque to Store Name, Store Street, Store Town, Store State / County, Store Postcode.</p>
										</div>
									</li>
									<li class="payment_method_cod">
										<input type="radio" data-order_button_text="" value="cod" name="payment_method" class="input-radio" id="payment_method_cod">
										<label for="payment_method_cod">Cash on Delivery 	</label>
										<div style="display:none;" class="payment_box payment_method_cod">
											<p>Pay with cash upon delivery.</p>
										</div>
									</li>
									<li class="payment_method_paypal">
										<input type="radio" data-order_button_text="Proceed to PayPal" value="paypal" name="payment_method" class="input-radio" id="payment_method_paypal">
										<label for="payment_method_paypal">
											PayPal <img alt="PayPal Acceptance Mark" src="../../images/shop/payment.png"><a title="What is PayPal?" onclick="javascript:window.open('https://www.paypal.com/gb/webapps/mpp/paypal-popup','WIPaypal','toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, width=1060, height=700'); return false;" class="about_paypal" href="https://www.paypal.com/gb/webapps/mpp/paypal-popup">What is PayPal?</a>	
										</label>
										<div style="display:none;" class="payment_box payment_method_paypal">
											<p>Pay via PayPal; you can pay with your credit card if you don’t have a PayPal account.</p>
										</div>
									</li>
								</ul>
								<div class="form-row place-order">
									<input type="submit" data-value="Place order" value="Place order" id="place_order" name="woocommerce_checkout_place_order" class="button alt">
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!-- End Content Page -->
	</div>


</asp:Content>

