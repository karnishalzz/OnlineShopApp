var app = new Vue({
    el: "#app",
    data: {
        editing: false,
        objectIndex: 0,
        loading: false,
        productModel: {
            id: 0,
            name: "product name",
            description: "product description",
            price: 5.99,
        },
        products: []
        
    },
    mounted() {
        this.getProducts();
    },
    methods: {

        getProduct(id) {
            this.loading = true;
            axios.get('/admin/products/' + id)
                .then(res => {
                    console.log(res);
                    var product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        price: product.price,
                    };

                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                })
        },
        getProducts() {
            this.loading = true;
            axios.get('/admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;;
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                })
        },
        createProduct() {
            this.loading = true;
            axios.post('/admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.push(res.data)
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                })
        },
        updateProduct() {
            this.loading = true;
            axios.put('/admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.splice(this.objectIndex, 1, res.data)
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                })
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete('/admin/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(this.objectIndex, 1)
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                })
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0
        }

    },
    computed: {

    }
})