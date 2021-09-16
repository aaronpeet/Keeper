<template>
  <div class="card">
    <img class="card-img rounded shadow" :src="vaultkeep.img" alt="keep image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <h5 class="card-title text-light text-left">
        {{ vaultkeep.name }}
      </h5>
      <img class="rounded-pill" :src="vaultkeep.creator.picture" alt="keep creator image">
    </div>
  </div>
</template>

<script>
export default {
  props: {
    vaultkeep: {
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
.rounded-pill{
    max-height: 40px;
}
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
