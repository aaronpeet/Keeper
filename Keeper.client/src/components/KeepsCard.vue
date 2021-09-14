<template>
  <div class="card">
    <img class="card-img rounded shadow action" :src="keep.img" alt="keep image">
    <div class="card-img-overlay">
      <h5 class="card-title text-light">
        {{ keep.name }}
      </h5>
      <img class="rounded-pill" :src="keep.creator.picture" alt="keep creator image">
    </div>
  </div>
</template>

<script>
export default {
  props: {
    keep: {
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

</style>
