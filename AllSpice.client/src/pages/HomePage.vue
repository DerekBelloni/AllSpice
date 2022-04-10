<template>
  <div class="container-fluid">
    <div class="row justify-content-center m-3">
      <div
        class="
          col-11
          bg-primary
          rounded
          elevation-2
          cover-img
          d-flex
          justify-content-center
          align-items-center
          banner-text
        "
      >
        <h2>All Spice</h2>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-6 bg-light rounded elevation-2">
        <div class="row">
          <div class="col-4 d-flex justify-content-center selectable">
            <h4>Home</h4>
          </div>
          <div class="col-4 d-flex justify-content-center selectable">
            <h4>My Recipes</h4>
          </div>
          <div class="col-4 d-flex justify-content-center selectable">
            <h4>Favorites</h4>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-3 elevation-2 m-3">
        <img
          class="img-fluid mt-1 rounded selectable"
          src="https://images.unsplash.com/photo-1611270629569-8b357cb88da9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8N3x8cGFzdGF8ZW58MHx8MHx8&auto=format&fit=crop&w=1000&q=60"
          alt=""
          data-bs-toggle="modal"
          data-bs-target="#recipe-modal"
        />
        <h4>Recipe Name</h4>
        <h6>Recipe Subtitle</h6>
        <h6>Recipe Category</h6>
      </div>
    </div>
  </div>
  <Modal />
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
.cover-img {
  background-image: url("https://images.unsplash.com/photo-1540420828642-fca2c5c18abe?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTZ8fGNvb2tpbmd8ZW58MHx8MHx8&auto=format&fit=crop&w=1000&q=60");
  background-size: cover;
  background-position: center;
  min-height: 40vh;
  min-width: 90%;
}

.banner-text {
  color: white;
  font-size: 200px;
  font-family: "Bebas Neue", cursive;
  font-family: "Fredoka One", cursive;
}

.card-border {
  border: black solid 2px;
}
</style>
