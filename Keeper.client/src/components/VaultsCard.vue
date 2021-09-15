<template>
  <div class="card">
    <img class="card-img rounded shadow action" src="http://placehold.it/200x200" alt="keep image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <h5 class="card-title text-light text-left">
        {{ vault.name }}
      </h5>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },

  setup() {
    return {}
  }
}
</script>

<style lang="scss" scoped>
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
