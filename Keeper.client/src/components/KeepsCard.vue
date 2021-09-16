<template>
  <div class="card" data-toggle="modal" :data-target="'#keepDetailsModal' + keep.id" title="View keep details">
    <img class="card-img rounded shadow" :src="keep.img" alt="keep image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <h5 class="card-title text-light text-left">
        {{ keep.name }}
      </h5>
      <router-link :to="{ name: 'About', params: {id: keep.creatorId} }" class="nav-link">
        <img class="rounded-pill" :src="keep.creator.picture" alt="keep creator image">
      </router-link>
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
.rounded-pill{
    max-height: 40px;
}
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
